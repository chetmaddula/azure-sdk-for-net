﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Iot.TimeSeriesInsights.Tests
{
    /// <summary>
    /// This class will initialize all the settings and create and instance of the Time Series Insights client.
    /// </summary>
    [Parallelizable(ParallelScope.Self)]
    public abstract class E2eTestBase : RecordedTestBase<TimeSeriesInsightsTestEnvironment>
    {
        protected static readonly int MaxTries = 1000;

        // Based on testing, the max length of models can be 27 only and works well for other resources as well. This can be updated when required.
        protected static readonly int MaxIdLength = 27;

        public E2eTestBase(bool isAsync)
         : base(isAsync, TestSettings.Instance.TestMode)
        {
            Sanitizer = new TestUrlSanitizer();
        }

        [SetUp]
        public virtual void SetupE2eTestBase()
        {
            TestDiagnostics = false;

            // TODO: set via client options and pipeline instead
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected TimeSeriesInsightsClient GetClient(TimeSeriesInsightsClientOptions options = null)
        {
            if (options == null)
            {
                options = new TimeSeriesInsightsClientOptions();
            }

            return InstrumentClient(
                new TimeSeriesInsightsClient(
                    TestEnvironment.TimeSeriesInsightsHostname,
                    TestEnvironment.Credential,
                    InstrumentClientOptions(options)));
        }

        protected TimeSeriesInsightsClient GetFakeClient()
        {
            return InstrumentClient(
                new TimeSeriesInsightsClient(
                    TestEnvironment.TimeSeriesInsightsHostname,
                    new FakeTokenCredential(),
                    InstrumentClientOptions(new TimeSeriesInsightsClientOptions())));
        }

        public async Task<ITimeSeriesId> GetUniqueTimeSeriesInstanceIdAsync(TimeSeriesInsightsClient tsiClient, int numOfIdProperties)
        {
            Assert.IsTrue(numOfIdProperties > 0 && numOfIdProperties <= 3);

            for (int tryNumber = 0; tryNumber < MaxTries; ++tryNumber)
            {
                var id = new List<string>();
                for (int i = 0; i < numOfIdProperties; i++)
                {
                    id.Add(Recording.GenerateAlphaNumericId("", 5));
                }

                ITimeSeriesId tsId;
                if (numOfIdProperties == 1)
                {
                    tsId = new TimeSeries1Id(id[0]);
                }
                else if (numOfIdProperties == 2)
                {
                    tsId = new TimeSeries2Id(id[0], id[1]);
                }
                else
                {
                    tsId = new TimeSeries3Id(id[0], id[1], id[2]);
                }

                Response<InstancesOperationResult[]> getInstancesResult = await tsiClient
                    .GetInstancesAsync(new List<ITimeSeriesId> { tsId })
                    .ConfigureAwait(false);

                if (getInstancesResult.Value?.First()?.Error != null)
                {
                    return tsId;
                }
            }

            throw new Exception($"Unique Id could not be found");
        }
    }
}
