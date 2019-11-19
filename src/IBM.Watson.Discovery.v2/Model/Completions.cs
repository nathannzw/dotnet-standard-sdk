/**
* (C) Copyright IBM Corp. 2018, 2019.
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

namespace IBM.Watson.Discovery.v2.Model
{
    /// <summary>
    /// An object containing an array of autocompletion suggestions.
    /// </summary>
    public class Completions
    {
        /// <summary>
        /// Array of autcomplete suggestion based on the provided prefix.
        /// </summary>
        [JsonProperty("completions", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> _Completions { get; set; }
    }

}
