using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class User
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("userLanguage")]
        public string UserLanguage { get; set; }

        [JsonPropertyName("timeZone")]
        public int TimeZone { get; set; }

        [JsonPropertyName("lng")]
        public string Lng { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("isValiPhone")]
        public int IsValidPhone { get; set; }

        [JsonPropertyName("kind")]
        public int Kind { get; set; }

        [JsonPropertyName("mailNotice")]
        public bool MailNotice { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("lastLoginIp")]
        public string LastLoginIp { get; set; }

        [JsonPropertyName("phoneNum")]
        public string PhoneNum { get; set; }

        [JsonPropertyName("approved")]
        public bool Approved { get; set; }

        [JsonPropertyName("area")]
        public string Area { get; set; }

        [JsonPropertyName("smsNotice")]
        public bool SmsNotice { get; set; }

        [JsonPropertyName("isAgent")]
        public int IsAgent { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("nickName")]
        public string NickName { get; set; }

        [JsonPropertyName("parentUserId")]
        public int ParentUserId { get; set; }

        [JsonPropertyName("customerCode")]
        public string CustomerCode { get; set; }

        [JsonPropertyName("counrty")]
        public string Country { get; set; }

        [JsonPropertyName("isPhoneNumReg")]
        public int IsPhoneNumReg { get; set; }

        [JsonPropertyName("createDate")]
        public string CreateDate { get; set; }

        [JsonPropertyName("rightlevel")]
        public int RightLevel { get; set; }

        [JsonPropertyName("appType")]
        public string AppType { get; set; }

        [JsonPropertyName("serverUrl")]
        public string ServerUrl { get; set; }

        [JsonPropertyName("lat")]
        public string Lat { get; set; }

        [JsonPropertyName("lastLoginTime")]
        public string LastLoginTime { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("agentCode")]
        public string AgentCode { get; set; }

        [JsonPropertyName("isValiEmail")]
        public int IsValiEmail { get; set; }

        [JsonPropertyName("accountName")]
        public string AccountName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("activeName")]
        public string ActiveName { get; set; }

        [JsonPropertyName("appAlias")]
        public string AppAlias { get; set; }

        [JsonPropertyName("isBigCustomer")]
        public int IsBigCustomer { get; set; }

        [JsonPropertyName("noticeType")]
        public string NoticeType { get; set; }
    }
}
