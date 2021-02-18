// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Iot.TimeSeriesInsights;

namespace Azure.Iot.TimeSeriesInsights.Models
{
    /// <summary> Result of a batch operation on a particular time series hierarchy. Hierarchy is set when operation is successful and error object is set when operation is unsuccessful. </summary>
    public partial class TimeSeriesHierarchyOrError
    {
        /// <summary> Initializes a new instance of TimeSeriesHierarchyOrError. </summary>
        internal TimeSeriesHierarchyOrError()
        {
        }

        /// <summary> Initializes a new instance of TimeSeriesHierarchyOrError. </summary>
        /// <param name="hierarchy"> Time series hierarchy object - set when the operation is successful. </param>
        /// <param name="error"> Error object - set when the operation is unsuccessful. </param>
        internal TimeSeriesHierarchyOrError(TimeSeriesHierarchy hierarchy, InstancesOperationError error)
        {
            Hierarchy = hierarchy;
            Error = error;
        }

        /// <summary> Time series hierarchy object - set when the operation is successful. </summary>
        public TimeSeriesHierarchy Hierarchy { get; }
        /// <summary> Error object - set when the operation is unsuccessful. </summary>
        public InstancesOperationError Error { get; }
    }
}
