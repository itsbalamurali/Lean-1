

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = OpenAPIDateConverter;

namespace QuantConnect.Brokerages.Exante.Model
{
    /// <summary>
    /// order duration type
    /// </summary>
    /// <value>order duration type</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Value
    {
        /// <summary>
        /// Enum Day for value: day
        /// </summary>
        [EnumMember(Value = "day")]
        Day = 1,

        /// <summary>
        /// Enum Attheclose for value: at_the_close
        /// </summary>
        [EnumMember(Value = "at_the_close")]
        Attheclose = 2,

        /// <summary>
        /// Enum Attheopening for value: at_the_opening
        /// </summary>
        [EnumMember(Value = "at_the_opening")]
        Attheopening = 3,

        /// <summary>
        /// Enum Fillorkill for value: fill_or_kill
        /// </summary>
        [EnumMember(Value = "fill_or_kill")]
        Fillorkill = 4,

        /// <summary>
        /// Enum Immediateorcancel for value: immediate_or_cancel
        /// </summary>
        [EnumMember(Value = "immediate_or_cancel")]
        Immediateorcancel = 5,

        /// <summary>
        /// Enum Goodtillcancel for value: good_till_cancel
        /// </summary>
        [EnumMember(Value = "good_till_cancel")]
        Goodtillcancel = 6,

        /// <summary>
        /// Enum Goodtilltime for value: good_till_time
        /// </summary>
        [EnumMember(Value = "good_till_time")]
        Goodtilltime = 7

    }

}
