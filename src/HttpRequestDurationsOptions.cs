using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Prometheus.Client.Collectors;

namespace Prometheus.Client.HttpRequestDurations
{
    /// <summary>
    ///     Options for RequestDurationsMiddleware
    /// </summary>
    public class HttpRequestDurationsOptions
    {
        /// <summary>
        ///     Metric name
        /// </summary>
        public string MetricName { get; set; }

        /// <summary>
        ///     <para>When true; the timestamp is added to the metric.</para>
        ///     <para>When false; the timestamp is NOT added.</para>
        ///     <para>Defaults to false.</para>
        /// </summary>
        public bool IncludeTimestamp { get; set; } = false;

        /// <summary>
        ///     HTTP status code (200, 400, 404 etc.)
        /// </summary>
        public bool IncludeStatusCode { get; set; }

        /// <summary>
        ///     HTTP method (GET, PUT, ...)
        /// </summary>
        public bool IncludeMethod { get; set; }

        /// <summary>
        ///     URL path
        /// </summary>
        public bool IncludePath { get; set; }

        /// <summary>
        ///     Ignore paths
        /// </summary>
        public string[] IgnoreRoutesConcrete { get; set; }

        /// <summary>
        ///     Ignore paths
        /// </summary>
        public string[] IgnoreRoutesContains { get; set; }

        /// <summary>
        ///     Ignore paths
        /// </summary>
        public string[] IgnoreRoutesStartWith { get; set; }

        /// <summary>
        ///     Collector Registry
        /// </summary>
        public ICollectorRegistry CollectorRegistry { get; set; }

        /// <summary>
        ///     Buckets
        /// </summary>
        public double[] Buckets { get; set; }

        /// <summary>
        ///     Custom Labels. Use only, if you cannot use 'relabel_configs' in Prometheus
        /// </summary>
        public Dictionary<string, Func<string>> CustomLabels { get; set; }

        /// <summary>
        ///     Normalize Path
        /// </summary>
        public Dictionary<Regex, string> CustomNormalizePath { get; set; }

        /// <summary>
        ///    Include Custom Labels
        /// </summary>
        public bool IncludeCustomLabels => CustomLabels != null;

        /// <summary>
        ///    Include Custom Normalize Path
        /// </summary>
        public bool IncludeCustomNormalizePath => CustomNormalizePath != null;

#if HasRoutes
        /// <summary>
        /// Try to use route name instead of raw url
        /// </summary>
        public bool UseRouteName { get; set; }

        /// <summary>
        ///     Adds controller name as a metric label. Defaults to false.
        /// </summary>
        public bool IncludeController { get; set; } = false;

        /// <summary>
        ///     Adds action name as a metric label. Defaults to false.
        /// </summary>
        public bool IncludeAction { get; set; } = false;
#endif

        /// <summary>
        ///    Should measure request
        /// </summary>
        public Func<HttpRequest, bool> ShouldMeasureRequest { get; set; }

        /// <summary>
        ///     Constructor
        /// </summary>
        public HttpRequestDurationsOptions()
        {
            MetricName = "http_request_duration_seconds";

            IncludeStatusCode = true;
            IncludeMethod = false;
            IncludePath = false;
        }
    }
}
