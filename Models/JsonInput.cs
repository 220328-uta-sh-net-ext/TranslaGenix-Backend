using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Actor
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public string? alternateId { get; set; }
        public string? displayName { get; set; }
        public object? detailEntry { get; set; }
    }

    public class AuthenticationContext
    {
        public object? authenticationProvider { get; set; }
        public object? credentialProvider { get; set; }
        public object? credentialType { get; set; }
        public object? issuer { get; set; }
        public int? authenticationStep { get; set; }
        public string? externalSessionId { get; set; }
        public object? @interface { get; set; }
    }

    public class Client
    {
        public object? userAgent { get; set; }
        public object? zone { get; set; }
        public object? device { get; set; }
        public object? id { get; set; }
        public string? ipAddress { get; set; }
        public object? geographicalContext { get; set; }
        public List<object>? ipChain { get; set; }
    }

    public class Data
    {
        public List<Event> events { get; set; }
    }

    public class DebugContext
    {
        public DebugData? debugData { get; set; }
    }

    public class DebugData
    {
        public string? requestUri { get; set; }
        public string? threatSuspected { get; set; }
    }

    public class Detail
    {
    }

    public class Event
    {
        public string? uuid { get; set; }
        public DateTime? published { get; set; }
        public string? eventType { get; set; }
        public string? version { get; set; }
        public string? displayMessage { get; set; }
        public string? severity { get; set; }
        public Client? client { get; set; }
        public object? device { get; set; }
        public Actor? actor { get; set; }
        public Outcome? outcome { get; set; }
        public List<Target> target { get; set; }
        public Transaction? transaction { get; set; }
        public DebugContext? debugContext { get; set; }
        public string? legacyEventType { get; set; }
        public AuthenticationContext? authenticationContext { get; set; }
        public SecurityContext? securityContext { get; set; }
        public object? insertionTimestamp { get; set; }
    }

    public class Outcome
    {
        public string? result { get; set; }
        public object? reason { get; set; }
    }

    public class JsonInput
    {
        public string? eventType { get; set; }
        public string? eventTypeVersion { get; set; }
        public string? cloudEventsVersion { get; set; }
        public string? source { get; set; }
        public string? eventId { get; set; }
        public Data data { get; set; }
        public DateTime? eventTime { get; set; }
        public string? contentType { get; set; }
    }

    public class SecurityContext
    {
        public int? asNumber { get; set; }
        public string? asOrg { get; set; }
        public string? isp { get; set; }
        public string? domain { get; set; }
        public bool? isProxy { get; set; }
    }

    public class Target
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public string alternateId { get; set; }
        public string displayName { get; set; }
        public object? detailEntry { get; set; }
    }

    public class Transaction
    {
        public object? type { get; set; }
        public string? id { get; set; }
        public Detail? detail { get; set; }
    }


}
