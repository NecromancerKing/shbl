﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SHBL.SPT.UI.Model.Auth.Responses
{
    public class TokenResponse 
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty(".issued")]
        public DateTime IssuedAt { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(".expires")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("firstTimeLogin")]
        public bool FirstTimeLogin { get; set; }

        [JsonProperty("roles")]
        public List<String> Roles { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("externalUserID")]
        public string ExternalUserID { get; set; }

        [JsonProperty("profilePicture")]
        public string ProfilePicture { get; set; }

        [JsonProperty("friends")]
        public List<String> Friends { get; set; }
    }
}
