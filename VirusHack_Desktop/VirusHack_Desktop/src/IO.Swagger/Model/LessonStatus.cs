using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LessonStatus
    {
        /// <summary>
        /// Enum Student for value: student
        /// </summary>
        [EnumMember(Value = "future")]
        Future = 1,

        /// <summary>
        /// Enum Teacher for value: teacher
        /// </summary>
        [EnumMember(Value = "present")]
        Present = 2,

        /// <summary>
        /// Enum Admin for value: admin
        /// </summary>
        [EnumMember(Value = "missed")]
        Missed = 3
    }
}
