/**
* Copyright 2018 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBM.WatsonDeveloperCloud.Assistant.v1.Model
{
    /// <summary>
    /// UpdateExample.
    /// </summary>
    public class UpdateExample : BaseModel
    {
        /// <summary>
        /// The text of the user input example. This string must conform to the following restrictions:
        /// - It cannot contain carriage return, newline, or tab characters.
        /// - It cannot consist of only whitespace characters.
        /// - It must be no longer than 1024 characters.
        /// </summary>
        /// <value>
        /// The text of the user input example. This string must conform to the following restrictions:
        /// - It cannot contain carriage return, newline, or tab characters.
        /// - It cannot consist of only whitespace characters.
        /// - It must be no longer than 1024 characters.
        /// </value>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
        /// <summary>
        /// An array of contextual entity mentions.
        /// </summary>
        /// <value>
        /// An array of contextual entity mentions.
        /// </value>
        [JsonProperty("mentions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Mentions> Mentions { get; set; }
    }

}
