// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.Iot.TimeSeriesInsights;

namespace Azure.Iot.TimeSeriesInsights.Models
{
    /// <summary> Partial list of time series instances returned in a single request. </summary>
    public partial class GetInstancesPage : PagedResponse
    {
        /// <summary> Initializes a new instance of GetInstancesPage. </summary>
        internal GetInstancesPage()
        {
            Instances = new ChangeTrackingList<TimeSeriesInstance>();
        }

        /// <summary> Initializes a new instance of GetInstancesPage. </summary>
        /// <param name="continuationToken"> If returned, this means that current results represent a partial result. Continuation token allows to get the next page of results. To get the next page of query results, send the same request with continuation token parameter in &quot;x-ms-continuation&quot; HTTP header. </param>
        /// <param name="instances"> Partial list of time series instances returned in a single request. Can be empty if server was unable to fill the page in this request, or there is no more objects when continuation token is null. </param>
        internal GetInstancesPage(string continuationToken, IReadOnlyList<TimeSeriesInstance> instances) : base(continuationToken)
        {
            Instances = instances;
        }

        /// <summary> Partial list of time series instances returned in a single request. Can be empty if server was unable to fill the page in this request, or there is no more objects when continuation token is null. </summary>
        public IReadOnlyList<TimeSeriesInstance> Instances { get; }
    }
}
