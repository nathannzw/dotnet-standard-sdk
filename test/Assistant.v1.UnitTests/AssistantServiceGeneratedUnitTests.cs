/**
* (C) Copyright IBM Corp. 2018, 2020.
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

using IBM.Cloud.SDK.Core.Http;
using IBM.Watson.Assistant.v1.Model;
using NSubstitute;
using System;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using IBM.Cloud.SDK.Core.Authentication.NoAuth;
using System.Threading.Tasks;

namespace IBM.Watson.Assistant.v1.UnitTests
{
    [TestClass]
    public class AssistantServiceUnitTests
    {
        #region Constructor
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_HttpClient_Null()
        {
            AssistantService service = new AssistantService(httpClient: null);
        }

        [TestMethod]
        public void ConstructorHttpClient()
        {
            AssistantService service = new AssistantService(new IBMHttpClient());
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void ConstructorExternalConfig()
        {
            var apikey = System.Environment.GetEnvironmentVariable("ASSISTANT_APIKEY");
            var url = System.Environment.GetEnvironmentVariable("ASSISTANT_URL");
            System.Environment.SetEnvironmentVariable("ASSISTANT_APIKEY", "apikey");
            System.Environment.SetEnvironmentVariable("ASSISTANT_URL", "http://www.url.com");
            AssistantService service = Substitute.For<AssistantService>("versionDate");
            Assert.IsNotNull(service);
            System.Environment.SetEnvironmentVariable("ASSISTANT_URL", url);
            System.Environment.SetEnvironmentVariable("ASSISTANT_APIKEY", apikey);
        }

        [TestMethod]
        public void Constructor()
        {
            AssistantService service = new AssistantService(new IBMHttpClient());
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void ConstructorAuthenticator()
        {
            AssistantService service = new AssistantService("versionDate", new NoAuthAuthenticator());
            Assert.IsNotNull(service);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorNoVersion()
        {
            AssistantService service = new AssistantService(null, new NoAuthAuthenticator());
        }

        [TestMethod]
        public void ConstructorNoUrl()
        {
            var apikey = System.Environment.GetEnvironmentVariable("ASSISTANT_APIKEY");
            var url = System.Environment.GetEnvironmentVariable("ASSISTANT_URL");
            System.Environment.SetEnvironmentVariable("ASSISTANT_APIKEY", "apikey");
            System.Environment.SetEnvironmentVariable("ASSISTANT_URL", null);
            AssistantService service = Substitute.For<AssistantService>("versionDate");
            Assert.IsTrue(service.ServiceUrl == "https://gateway.watsonplatform.net/assistant/api");
            System.Environment.SetEnvironmentVariable("ASSISTANT_URL", url);
            System.Environment.SetEnvironmentVariable("ASSISTANT_APIKEY", apikey);
        }
        #endregion

        [TestMethod]
        public void TestCaptureGroupModel()
        {

            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup testRequestModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            Assert.IsTrue(testRequestModel.Group == "testString");
            Assert.IsTrue(testRequestModel.Location == CaptureGroupLocation);
        }

        [TestMethod]
        public void TestCounterexampleModel()
        {

            Counterexample testRequestModel = new Counterexample()
            {
                Text = "testString",
            };

            Assert.IsTrue(testRequestModel.Text == "testString");
        }

        [TestMethod]
        public void TestCreateEntityModel()
        {
            var CreateValueMetadata = new Dictionary<string, object>();
            var CreateValueSynonyms = new List<string> { "testString" };
            var CreateValuePatterns = new List<string> { "testString" };
            CreateValue CreateValueModel = new CreateValue()
            {
                Value = "testString",
                Metadata = CreateValueMetadata,
                Type = "synonyms",
                Synonyms = CreateValueSynonyms,
                Patterns = CreateValuePatterns,
            };

            var CreateEntityMetadata = new Dictionary<string, object>();
            var CreateEntityValues = new List<CreateValue> { CreateValueModel };
            CreateEntity testRequestModel = new CreateEntity()
            {
                Entity = "testString",
                Description = "testString",
                Metadata = CreateEntityMetadata,
                FuzzyMatch = true,
                Values = CreateEntityValues
            };

            Assert.IsTrue(testRequestModel.Entity == "testString");
            Assert.IsTrue(testRequestModel.Description == "testString");
            Assert.IsTrue(testRequestModel.Metadata == CreateEntityMetadata);
            Assert.IsTrue(testRequestModel.FuzzyMatch == true);
            Assert.IsTrue(testRequestModel.Values == CreateEntityValues);
        }

        [TestMethod]
        public void TestCreateIntentModel()
        {
            var MentionLocation = new List<long?> { 38 };
            Mention MentionModel = new Mention()
            {
                Entity = "testString",
                Location = MentionLocation
            };

            var ExampleMentions = new List<Mention> { MentionModel };
            Example ExampleModel = new Example()
            {
                Text = "testString",
                Mentions = ExampleMentions,
            };

            var CreateIntentExamples = new List<Example> { ExampleModel };
            CreateIntent testRequestModel = new CreateIntent()
            {
                Intent = "testString",
                Description = "testString",
                Examples = CreateIntentExamples
            };

            Assert.IsTrue(testRequestModel.Intent == "testString");
            Assert.IsTrue(testRequestModel.Description == "testString");
            Assert.IsTrue(testRequestModel.Examples == CreateIntentExamples);
        }

        [TestMethod]
        public void TestCreateValueModel()
        {

            var CreateValueMetadata = new Dictionary<string, object>();
            var CreateValueSynonyms = new List<string> { "testString" };
            var CreateValuePatterns = new List<string> { "testString" };
            CreateValue testRequestModel = new CreateValue()
            {
                Value = "testString",
                Metadata = CreateValueMetadata,
                Type = "synonyms",
                Synonyms = CreateValueSynonyms,
                Patterns = CreateValuePatterns,
            };

            Assert.IsTrue(testRequestModel.Value == "testString");
            Assert.IsTrue(testRequestModel.Metadata == CreateValueMetadata);
            Assert.IsTrue(testRequestModel.Type == "synonyms");
            Assert.IsTrue(testRequestModel.Synonyms == CreateValueSynonyms);
            Assert.IsTrue(testRequestModel.Patterns == CreateValuePatterns);
        }

        [TestMethod]
        public void TestDialogNodeModel()
        {
            var DialogNodeActionParameters = new Dictionary<string, object>();
            DialogNodeAction DialogNodeActionModel = new DialogNodeAction()
            {
                Name = "testString",
                Type = "client",
                Parameters = DialogNodeActionParameters,
                ResultVariable = "testString",
                Credentials = "testString"
            };

            DialogNodeNextStep DialogNodeNextStepModel = new DialogNodeNextStep()
            {
                Behavior = "get_user_input",
                DialogNode = "testString",
                Selector = "condition"
            };

            DialogNodeOutputModifiers DialogNodeOutputModifiersModel = new DialogNodeOutputModifiers()
            {
                Overwrite = true
            };

            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            DialogNodeOutputTextValuesElement DialogNodeOutputTextValuesElementModel = new DialogNodeOutputTextValuesElement()
            {
                Text = "testString"
            };

            var DialogNodeOutputGenericValues = new List<DialogNodeOutputTextValuesElement> { DialogNodeOutputTextValuesElementModel };
            var DialogNodeOutputGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogNodeOutputGeneric DialogNodeOutputGenericModel = new DialogNodeOutputGeneric()
            {
                ResponseType = "text",
                Values = DialogNodeOutputGenericValues,
                SelectionPolicy = "sequential",
                Delimiter = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogNodeOutputGenericOptions,
                MessageToHumanAgent = "testString",
                Query = "testString",
                QueryType = "natural_language",
                Filter = "testString",
                DiscoveryVersion = "testString"
            };

            var DialogNodeOutputGeneric = new List<DialogNodeOutputGeneric> { DialogNodeOutputGenericModel };
            DialogNodeOutput DialogNodeOutputModel = new DialogNodeOutput()
            {
                Generic = DialogNodeOutputGeneric,
                Modifiers = DialogNodeOutputModifiersModel
            };

            var DialogNodeContext = new Dictionary<string, object>();
            var DialogNodeMetadata = new Dictionary<string, object>();
            var DialogNodeActions = new List<DialogNodeAction> { DialogNodeActionModel };
            DialogNode testRequestModel = new DialogNode()
            {
                _DialogNode = "testString",
                Description = "testString",
                Conditions = "testString",
                Parent = "testString",
                PreviousSibling = "testString",
                Output = DialogNodeOutputModel,
                Context = DialogNodeContext,
                Metadata = DialogNodeMetadata,
                NextStep = DialogNodeNextStepModel,
                Title = "testString",
                Type = "standard",
                EventName = "focus",
                Variable = "testString",
                Actions = DialogNodeActions,
                DigressIn = "not_available",
                DigressOut = "allow_returning",
                DigressOutSlots = "not_allowed",
                UserLabel = "testString",
                DisambiguationOptOut = true,
            };

            Assert.IsTrue(testRequestModel._DialogNode == "testString");
            Assert.IsTrue(testRequestModel.Description == "testString");
            Assert.IsTrue(testRequestModel.Conditions == "testString");
            Assert.IsTrue(testRequestModel.Parent == "testString");
            Assert.IsTrue(testRequestModel.PreviousSibling == "testString");
            Assert.IsTrue(testRequestModel.Output == DialogNodeOutputModel);
            Assert.IsTrue(testRequestModel.Context == DialogNodeContext);
            Assert.IsTrue(testRequestModel.Metadata == DialogNodeMetadata);
            Assert.IsTrue(testRequestModel.NextStep == DialogNodeNextStepModel);
            Assert.IsTrue(testRequestModel.Title == "testString");
            Assert.IsTrue(testRequestModel.Type == "standard");
            Assert.IsTrue(testRequestModel.EventName == "focus");
            Assert.IsTrue(testRequestModel.Variable == "testString");
            Assert.IsTrue(testRequestModel.Actions == DialogNodeActions);
            Assert.IsTrue(testRequestModel.DigressIn == "not_available");
            Assert.IsTrue(testRequestModel.DigressOut == "allow_returning");
            Assert.IsTrue(testRequestModel.DigressOutSlots == "not_allowed");
            Assert.IsTrue(testRequestModel.UserLabel == "testString");
            Assert.IsTrue(testRequestModel.DisambiguationOptOut == true);
        }

        [TestMethod]
        public void TestDialogNodeActionModel()
        {

            var DialogNodeActionParameters = new Dictionary<string, object>();
            DialogNodeAction testRequestModel = new DialogNodeAction()
            {
                Name = "testString",
                Type = "client",
                Parameters = DialogNodeActionParameters,
                ResultVariable = "testString",
                Credentials = "testString"
            };

            Assert.IsTrue(testRequestModel.Name == "testString");
            Assert.IsTrue(testRequestModel.Type == "client");
            Assert.IsTrue(testRequestModel.Parameters == DialogNodeActionParameters);
            Assert.IsTrue(testRequestModel.ResultVariable == "testString");
            Assert.IsTrue(testRequestModel.Credentials == "testString");
        }

        [TestMethod]
        public void TestDialogNodeNextStepModel()
        {

            DialogNodeNextStep testRequestModel = new DialogNodeNextStep()
            {
                Behavior = "get_user_input",
                DialogNode = "testString",
                Selector = "condition"
            };

            Assert.IsTrue(testRequestModel.Behavior == "get_user_input");
            Assert.IsTrue(testRequestModel.DialogNode == "testString");
            Assert.IsTrue(testRequestModel.Selector == "condition");
        }

        [TestMethod]
        public void TestDialogNodeOutputGenericModel()
        {
            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            DialogNodeOutputTextValuesElement DialogNodeOutputTextValuesElementModel = new DialogNodeOutputTextValuesElement()
            {
                Text = "testString"
            };

            var DialogNodeOutputGenericValues = new List<DialogNodeOutputTextValuesElement> { DialogNodeOutputTextValuesElementModel };
            var DialogNodeOutputGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogNodeOutputGeneric testRequestModel = new DialogNodeOutputGeneric()
            {
                ResponseType = "text",
                Values = DialogNodeOutputGenericValues,
                SelectionPolicy = "sequential",
                Delimiter = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogNodeOutputGenericOptions,
                MessageToHumanAgent = "testString",
                Query = "testString",
                QueryType = "natural_language",
                Filter = "testString",
                DiscoveryVersion = "testString"
            };

            Assert.IsTrue(testRequestModel.ResponseType == "text");
            Assert.IsTrue(testRequestModel.Values == DialogNodeOutputGenericValues);
            Assert.IsTrue(testRequestModel.SelectionPolicy == "sequential");
            Assert.IsTrue(testRequestModel.Delimiter == "testString");
            Assert.IsTrue(testRequestModel.Time == 38);
            Assert.IsTrue(testRequestModel.Typing == true);
            Assert.IsTrue(testRequestModel.Source == "testString");
            Assert.IsTrue(testRequestModel.Title == "testString");
            Assert.IsTrue(testRequestModel.Description == "testString");
            Assert.IsTrue(testRequestModel.Preference == "dropdown");
            Assert.IsTrue(testRequestModel.Options == DialogNodeOutputGenericOptions);
            Assert.IsTrue(testRequestModel.MessageToHumanAgent == "testString");
            Assert.IsTrue(testRequestModel.Query == "testString");
            Assert.IsTrue(testRequestModel.QueryType == "natural_language");
            Assert.IsTrue(testRequestModel.Filter == "testString");
            Assert.IsTrue(testRequestModel.DiscoveryVersion == "testString");
        }

        [TestMethod]
        public void TestDialogNodeOutputModifiersModel()
        {

            DialogNodeOutputModifiers testRequestModel = new DialogNodeOutputModifiers()
            {
                Overwrite = true
            };

            Assert.IsTrue(testRequestModel.Overwrite == true);
        }

        [TestMethod]
        public void TestDialogNodeOutputOptionsElementModel()
        {
            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement testRequestModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            Assert.IsTrue(testRequestModel.Label == "testString");
            Assert.IsTrue(testRequestModel.Value == DialogNodeOutputOptionsElementValueModel);
        }

        [TestMethod]
        public void TestDialogNodeOutputOptionsElementValueModel()
        {
            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue testRequestModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            Assert.IsTrue(testRequestModel.Input == MessageInputModel);
            Assert.IsTrue(testRequestModel.Intents == DialogNodeOutputOptionsElementValueIntents);
            Assert.IsTrue(testRequestModel.Entities == DialogNodeOutputOptionsElementValueEntities);
        }

        [TestMethod]
        public void TestDialogNodeOutputTextValuesElementModel()
        {

            DialogNodeOutputTextValuesElement testRequestModel = new DialogNodeOutputTextValuesElement()
            {
                Text = "testString"
            };

            Assert.IsTrue(testRequestModel.Text == "testString");
        }

        [TestMethod]
        public void TestDialogNodeVisitedDetailsModel()
        {

            DialogNodeVisitedDetails testRequestModel = new DialogNodeVisitedDetails()
            {
                DialogNode = "testString",
                Title = "testString",
                Conditions = "testString"
            };

            Assert.IsTrue(testRequestModel.DialogNode == "testString");
            Assert.IsTrue(testRequestModel.Title == "testString");
            Assert.IsTrue(testRequestModel.Conditions == "testString");
        }

        [TestMethod]
        public void TestDialogSuggestionModel()
        {
            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            var DialogSuggestionResponseGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogSuggestionResponseGeneric DialogSuggestionResponseGenericModel = new DialogSuggestionResponseGeneric()
            {
                ResponseType = "text",
                Text = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogSuggestionResponseGenericOptions,
                MessageToHumanAgent = "testString",
                DialogNode = "testString"
            };

            DialogNodeVisitedDetails DialogNodeVisitedDetailsModel = new DialogNodeVisitedDetails()
            {
                DialogNode = "testString",
                Title = "testString",
                Conditions = "testString"
            };

            var DialogSuggestionOutputNodesVisited = new List<string> { "testString" };
            var DialogSuggestionOutputNodesVisitedDetails = new List<DialogNodeVisitedDetails> { DialogNodeVisitedDetailsModel };
            var DialogSuggestionOutputText = new List<string> { "testString" };
            var DialogSuggestionOutputGeneric = new List<DialogSuggestionResponseGeneric> { DialogSuggestionResponseGenericModel };
            DialogSuggestionOutput DialogSuggestionOutputModel = new DialogSuggestionOutput()
            {
                NodesVisited = DialogSuggestionOutputNodesVisited,
                NodesVisitedDetails = DialogSuggestionOutputNodesVisitedDetails,
                Text = DialogSuggestionOutputText,
                Generic = DialogSuggestionOutputGeneric
            };

            var DialogSuggestionValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogSuggestionValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogSuggestionValue DialogSuggestionValueModel = new DialogSuggestionValue()
            {
                Input = MessageInputModel,
                Intents = DialogSuggestionValueIntents,
                Entities = DialogSuggestionValueEntities
            };

            DialogSuggestion testRequestModel = new DialogSuggestion()
            {
                Label = "testString",
                Value = DialogSuggestionValueModel,
                Output = DialogSuggestionOutputModel,
                DialogNode = "testString"
            };

            Assert.IsTrue(testRequestModel.Label == "testString");
            Assert.IsTrue(testRequestModel.Value == DialogSuggestionValueModel);
            Assert.IsTrue(testRequestModel.Output == DialogSuggestionOutputModel);
            Assert.IsTrue(testRequestModel.DialogNode == "testString");
        }

        [TestMethod]
        public void TestDialogSuggestionResponseGenericModel()
        {
            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            var DialogSuggestionResponseGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogSuggestionResponseGeneric testRequestModel = new DialogSuggestionResponseGeneric()
            {
                ResponseType = "text",
                Text = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogSuggestionResponseGenericOptions,
                MessageToHumanAgent = "testString",
                DialogNode = "testString"
            };

            Assert.IsTrue(testRequestModel.ResponseType == "text");
            Assert.IsTrue(testRequestModel.Text == "testString");
            Assert.IsTrue(testRequestModel.Time == 38);
            Assert.IsTrue(testRequestModel.Typing == true);
            Assert.IsTrue(testRequestModel.Source == "testString");
            Assert.IsTrue(testRequestModel.Title == "testString");
            Assert.IsTrue(testRequestModel.Description == "testString");
            Assert.IsTrue(testRequestModel.Preference == "dropdown");
            Assert.IsTrue(testRequestModel.Options == DialogSuggestionResponseGenericOptions);
            Assert.IsTrue(testRequestModel.MessageToHumanAgent == "testString");
            Assert.IsTrue(testRequestModel.DialogNode == "testString");
        }

        [TestMethod]
        public void TestDialogSuggestionValueModel()
        {
            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogSuggestionValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogSuggestionValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogSuggestionValue testRequestModel = new DialogSuggestionValue()
            {
                Input = MessageInputModel,
                Intents = DialogSuggestionValueIntents,
                Entities = DialogSuggestionValueEntities
            };

            Assert.IsTrue(testRequestModel.Input == MessageInputModel);
            Assert.IsTrue(testRequestModel.Intents == DialogSuggestionValueIntents);
            Assert.IsTrue(testRequestModel.Entities == DialogSuggestionValueEntities);
        }

        [TestMethod]
        public void TestExampleModel()
        {
            var MentionLocation = new List<long?> { 38 };
            Mention MentionModel = new Mention()
            {
                Entity = "testString",
                Location = MentionLocation
            };

            var ExampleMentions = new List<Mention> { MentionModel };
            Example testRequestModel = new Example()
            {
                Text = "testString",
                Mentions = ExampleMentions,
            };

            Assert.IsTrue(testRequestModel.Text == "testString");
            Assert.IsTrue(testRequestModel.Mentions == ExampleMentions);
        }

        [TestMethod]
        public void TestLogMessageModel()
        {

            LogMessage testRequestModel = new LogMessage()
            {
                Level = "info",
                Msg = "testString"
            };

            Assert.IsTrue(testRequestModel.Level == "info");
            Assert.IsTrue(testRequestModel.Msg == "testString");
        }

        [TestMethod]
        public void TestMentionModel()
        {

            var MentionLocation = new List<long?> { 38 };
            Mention testRequestModel = new Mention()
            {
                Entity = "testString",
                Location = MentionLocation
            };

            Assert.IsTrue(testRequestModel.Entity == "testString");
            Assert.IsTrue(testRequestModel.Location == MentionLocation);
        }

        [TestMethod]
        public void TestMessageContextMetadataModel()
        {

            MessageContextMetadata testRequestModel = new MessageContextMetadata()
            {
                Deployment = "testString",
                UserId = "testString"
            };

            Assert.IsTrue(testRequestModel.Deployment == "testString");
            Assert.IsTrue(testRequestModel.UserId == "testString");
        }

        [TestMethod]
        public void TestMessageRequestModel()
        {
            var DialogNodeActionParameters = new Dictionary<string, object>();
            DialogNodeAction DialogNodeActionModel = new DialogNodeAction()
            {
                Name = "testString",
                Type = "client",
                Parameters = DialogNodeActionParameters,
                ResultVariable = "testString",
                Credentials = "testString"
            };

            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            var DialogSuggestionResponseGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogSuggestionResponseGeneric DialogSuggestionResponseGenericModel = new DialogSuggestionResponseGeneric()
            {
                ResponseType = "text",
                Text = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogSuggestionResponseGenericOptions,
                MessageToHumanAgent = "testString",
                DialogNode = "testString"
            };

            DialogNodeVisitedDetails DialogNodeVisitedDetailsModel = new DialogNodeVisitedDetails()
            {
                DialogNode = "testString",
                Title = "testString",
                Conditions = "testString"
            };

            var DialogSuggestionOutputNodesVisited = new List<string> { "testString" };
            var DialogSuggestionOutputNodesVisitedDetails = new List<DialogNodeVisitedDetails> { DialogNodeVisitedDetailsModel };
            var DialogSuggestionOutputText = new List<string> { "testString" };
            var DialogSuggestionOutputGeneric = new List<DialogSuggestionResponseGeneric> { DialogSuggestionResponseGenericModel };
            DialogSuggestionOutput DialogSuggestionOutputModel = new DialogSuggestionOutput()
            {
                NodesVisited = DialogSuggestionOutputNodesVisited,
                NodesVisitedDetails = DialogSuggestionOutputNodesVisitedDetails,
                Text = DialogSuggestionOutputText,
                Generic = DialogSuggestionOutputGeneric
            };

            var DialogSuggestionValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogSuggestionValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogSuggestionValue DialogSuggestionValueModel = new DialogSuggestionValue()
            {
                Input = MessageInputModel,
                Intents = DialogSuggestionValueIntents,
                Entities = DialogSuggestionValueEntities
            };

            DialogSuggestion DialogSuggestionModel = new DialogSuggestion()
            {
                Label = "testString",
                Value = DialogSuggestionValueModel,
                Output = DialogSuggestionOutputModel,
                DialogNode = "testString"
            };

            var RuntimeResponseGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            var RuntimeResponseGenericSuggestions = new List<DialogSuggestion> { DialogSuggestionModel };
            RuntimeResponseGeneric RuntimeResponseGenericModel = new RuntimeResponseGeneric()
            {
                ResponseType = "text",
                Text = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = RuntimeResponseGenericOptions,
                MessageToHumanAgent = "testString",
                DialogNode = "testString",
                Suggestions = RuntimeResponseGenericSuggestions
            };

            LogMessage LogMessageModel = new LogMessage()
            {
                Level = "info",
                Msg = "testString"
            };

            var OutputDataNodesVisited = new List<string> { "testString" };
            var OutputDataNodesVisitedDetails = new List<DialogNodeVisitedDetails> { DialogNodeVisitedDetailsModel };
            var OutputDataLogMessages = new List<LogMessage> { LogMessageModel };
            var OutputDataText = new List<string> { "testString" };
            var OutputDataGeneric = new List<RuntimeResponseGeneric> { RuntimeResponseGenericModel };
            OutputData OutputDataModel = new OutputData()
            {
                NodesVisited = OutputDataNodesVisited,
                NodesVisitedDetails = OutputDataNodesVisitedDetails,
                LogMessages = OutputDataLogMessages,
                Text = OutputDataText,
                Generic = OutputDataGeneric
            };

            MessageContextMetadata MessageContextMetadataModel = new MessageContextMetadata()
            {
                Deployment = "testString",
                UserId = "testString"
            };

            SystemResponse SystemResponseModel = new SystemResponse()
            {
            };

            Context ContextModel = new Context()
            {
                ConversationId = "testString",
                System = SystemResponseModel,
                Metadata = MessageContextMetadataModel
            };

            var MessageRequestIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var MessageRequestEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            MessageRequest testRequestModel = new MessageRequest()
            {
                Input = MessageInputModel,
                Intents = MessageRequestIntents,
                Entities = MessageRequestEntities,
                AlternateIntents = true,
                Context = ContextModel,
                Output = OutputDataModel,
            };

            Assert.IsTrue(testRequestModel.Input == MessageInputModel);
            Assert.IsTrue(testRequestModel.Intents == MessageRequestIntents);
            Assert.IsTrue(testRequestModel.Entities == MessageRequestEntities);
            Assert.IsTrue(testRequestModel.AlternateIntents == true);
            Assert.IsTrue(testRequestModel.Context == ContextModel);
            Assert.IsTrue(testRequestModel.Output == OutputDataModel);
        }

        [TestMethod]
        public void TestRuntimeEntityModel()
        {
            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity testRequestModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            Assert.IsTrue(testRequestModel.Entity == "testString");
            Assert.IsTrue(testRequestModel.Location == RuntimeEntityLocation);
            Assert.IsTrue(testRequestModel.Value == "testString");
            Assert.IsTrue(testRequestModel.Confidence == 72.5f);
            Assert.IsTrue(testRequestModel.Metadata == RuntimeEntityMetadata);
            Assert.IsTrue(testRequestModel.Groups == RuntimeEntityGroups);
        }

        [TestMethod]
        public void TestRuntimeIntentModel()
        {

            RuntimeIntent testRequestModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            Assert.IsTrue(testRequestModel.Intent == "testString");
            Assert.IsTrue(testRequestModel.Confidence == 72.5f);
        }

        [TestMethod]
        public void TestRuntimeResponseGenericModel()
        {
            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            var DialogSuggestionResponseGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogSuggestionResponseGeneric DialogSuggestionResponseGenericModel = new DialogSuggestionResponseGeneric()
            {
                ResponseType = "text",
                Text = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogSuggestionResponseGenericOptions,
                MessageToHumanAgent = "testString",
                DialogNode = "testString"
            };

            DialogNodeVisitedDetails DialogNodeVisitedDetailsModel = new DialogNodeVisitedDetails()
            {
                DialogNode = "testString",
                Title = "testString",
                Conditions = "testString"
            };

            var DialogSuggestionOutputNodesVisited = new List<string> { "testString" };
            var DialogSuggestionOutputNodesVisitedDetails = new List<DialogNodeVisitedDetails> { DialogNodeVisitedDetailsModel };
            var DialogSuggestionOutputText = new List<string> { "testString" };
            var DialogSuggestionOutputGeneric = new List<DialogSuggestionResponseGeneric> { DialogSuggestionResponseGenericModel };
            DialogSuggestionOutput DialogSuggestionOutputModel = new DialogSuggestionOutput()
            {
                NodesVisited = DialogSuggestionOutputNodesVisited,
                NodesVisitedDetails = DialogSuggestionOutputNodesVisitedDetails,
                Text = DialogSuggestionOutputText,
                Generic = DialogSuggestionOutputGeneric
            };

            var DialogSuggestionValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogSuggestionValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogSuggestionValue DialogSuggestionValueModel = new DialogSuggestionValue()
            {
                Input = MessageInputModel,
                Intents = DialogSuggestionValueIntents,
                Entities = DialogSuggestionValueEntities
            };

            DialogSuggestion DialogSuggestionModel = new DialogSuggestion()
            {
                Label = "testString",
                Value = DialogSuggestionValueModel,
                Output = DialogSuggestionOutputModel,
                DialogNode = "testString"
            };

            var RuntimeResponseGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            var RuntimeResponseGenericSuggestions = new List<DialogSuggestion> { DialogSuggestionModel };
            RuntimeResponseGeneric testRequestModel = new RuntimeResponseGeneric()
            {
                ResponseType = "text",
                Text = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = RuntimeResponseGenericOptions,
                MessageToHumanAgent = "testString",
                DialogNode = "testString",
                Suggestions = RuntimeResponseGenericSuggestions
            };

            Assert.IsTrue(testRequestModel.ResponseType == "text");
            Assert.IsTrue(testRequestModel.Text == "testString");
            Assert.IsTrue(testRequestModel.Time == 38);
            Assert.IsTrue(testRequestModel.Typing == true);
            Assert.IsTrue(testRequestModel.Source == "testString");
            Assert.IsTrue(testRequestModel.Title == "testString");
            Assert.IsTrue(testRequestModel.Description == "testString");
            Assert.IsTrue(testRequestModel.Preference == "dropdown");
            Assert.IsTrue(testRequestModel.Options == RuntimeResponseGenericOptions);
            Assert.IsTrue(testRequestModel.MessageToHumanAgent == "testString");
            Assert.IsTrue(testRequestModel.DialogNode == "testString");
            Assert.IsTrue(testRequestModel.Suggestions == RuntimeResponseGenericSuggestions);
        }

        [TestMethod]
        public void TestSynonymModel()
        {

            Synonym testRequestModel = new Synonym()
            {
                _Synonym = "testString",
            };

            Assert.IsTrue(testRequestModel._Synonym == "testString");
        }

        [TestMethod]
        public void TestWebhookModel()
        {
            WebhookHeader WebhookHeaderModel = new WebhookHeader()
            {
                Name = "testString",
                Value = "testString"
            };

            var WebhookHeaders = new List<WebhookHeader> { WebhookHeaderModel };
            Webhook testRequestModel = new Webhook()
            {
                Url = "testString",
                Name = "testString",
                Headers = WebhookHeaders
            };

            Assert.IsTrue(testRequestModel.Url == "testString");
            Assert.IsTrue(testRequestModel.Name == "testString");
            Assert.IsTrue(testRequestModel.Headers == WebhookHeaders);
        }

        [TestMethod]
        public void TestWebhookHeaderModel()
        {

            WebhookHeader testRequestModel = new WebhookHeader()
            {
                Name = "testString",
                Value = "testString"
            };

            Assert.IsTrue(testRequestModel.Name == "testString");
            Assert.IsTrue(testRequestModel.Value == "testString");
        }

        [TestMethod]
        public void TestWorkspaceSystemSettingsModel()
        {
            WorkspaceSystemSettingsOffTopic WorkspaceSystemSettingsOffTopicModel = new WorkspaceSystemSettingsOffTopic()
            {
                Enabled = true
            };

            WorkspaceSystemSettingsDisambiguation WorkspaceSystemSettingsDisambiguationModel = new WorkspaceSystemSettingsDisambiguation()
            {
                Prompt = "testString",
                NoneOfTheAbovePrompt = "testString",
                Enabled = true,
                Sensitivity = "auto",
                Randomize = true,
                MaxSuggestions = 38,
                SuggestionTextPolicy = "testString"
            };

            WorkspaceSystemSettingsTooling WorkspaceSystemSettingsToolingModel = new WorkspaceSystemSettingsTooling()
            {
                StoreGenericResponses = true
            };

            var WorkspaceSystemSettingsHumanAgentAssist = new Dictionary<string, object>();
            WorkspaceSystemSettings testRequestModel = new WorkspaceSystemSettings()
            {
                Tooling = WorkspaceSystemSettingsToolingModel,
                Disambiguation = WorkspaceSystemSettingsDisambiguationModel,
                HumanAgentAssist = WorkspaceSystemSettingsHumanAgentAssist,
                OffTopic = WorkspaceSystemSettingsOffTopicModel
            };

            Assert.IsTrue(testRequestModel.Tooling == WorkspaceSystemSettingsToolingModel);
            Assert.IsTrue(testRequestModel.Disambiguation == WorkspaceSystemSettingsDisambiguationModel);
            Assert.IsTrue(testRequestModel.HumanAgentAssist == WorkspaceSystemSettingsHumanAgentAssist);
            Assert.IsTrue(testRequestModel.OffTopic == WorkspaceSystemSettingsOffTopicModel);
        }

        [TestMethod]
        public void TestWorkspaceSystemSettingsDisambiguationModel()
        {

            WorkspaceSystemSettingsDisambiguation testRequestModel = new WorkspaceSystemSettingsDisambiguation()
            {
                Prompt = "testString",
                NoneOfTheAbovePrompt = "testString",
                Enabled = true,
                Sensitivity = "auto",
                Randomize = true,
                MaxSuggestions = 38,
                SuggestionTextPolicy = "testString"
            };

            Assert.IsTrue(testRequestModel.Prompt == "testString");
            Assert.IsTrue(testRequestModel.NoneOfTheAbovePrompt == "testString");
            Assert.IsTrue(testRequestModel.Enabled == true);
            Assert.IsTrue(testRequestModel.Sensitivity == "auto");
            Assert.IsTrue(testRequestModel.Randomize == true);
            Assert.IsTrue(testRequestModel.MaxSuggestions == 38);
            Assert.IsTrue(testRequestModel.SuggestionTextPolicy == "testString");
        }

        [TestMethod]
        public void TestWorkspaceSystemSettingsOffTopicModel()
        {

            WorkspaceSystemSettingsOffTopic testRequestModel = new WorkspaceSystemSettingsOffTopic()
            {
                Enabled = true
            };

            Assert.IsTrue(testRequestModel.Enabled == true);
        }

        [TestMethod]
        public void TestWorkspaceSystemSettingsToolingModel()
        {

            WorkspaceSystemSettingsTooling testRequestModel = new WorkspaceSystemSettingsTooling()
            {
                StoreGenericResponses = true
            };

            Assert.IsTrue(testRequestModel.StoreGenericResponses == true);
        }

        [TestMethod]
        public void TestContextModel()
        {
            MessageContextMetadata MessageContextMetadataModel = new MessageContextMetadata()
            {
                Deployment = "testString",
                UserId = "testString"
            };

            SystemResponse SystemResponseModel = new SystemResponse()
            {
            };

            Context testRequestModel = new Context()
            {
                ConversationId = "testString",
                System = SystemResponseModel,
                Metadata = MessageContextMetadataModel
            };

            Assert.IsTrue(testRequestModel.ConversationId == "testString");
            Assert.IsTrue(testRequestModel.System == SystemResponseModel);
            Assert.IsTrue(testRequestModel.Metadata == MessageContextMetadataModel);
        }

        [TestMethod]
        public void TestDialogNodeOutputModel()
        {
            DialogNodeOutputModifiers DialogNodeOutputModifiersModel = new DialogNodeOutputModifiers()
            {
                Overwrite = true
            };

            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            DialogNodeOutputTextValuesElement DialogNodeOutputTextValuesElementModel = new DialogNodeOutputTextValuesElement()
            {
                Text = "testString"
            };

            var DialogNodeOutputGenericValues = new List<DialogNodeOutputTextValuesElement> { DialogNodeOutputTextValuesElementModel };
            var DialogNodeOutputGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogNodeOutputGeneric DialogNodeOutputGenericModel = new DialogNodeOutputGeneric()
            {
                ResponseType = "text",
                Values = DialogNodeOutputGenericValues,
                SelectionPolicy = "sequential",
                Delimiter = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogNodeOutputGenericOptions,
                MessageToHumanAgent = "testString",
                Query = "testString",
                QueryType = "natural_language",
                Filter = "testString",
                DiscoveryVersion = "testString"
            };

            var DialogNodeOutputGeneric = new List<DialogNodeOutputGeneric> { DialogNodeOutputGenericModel };
            DialogNodeOutput testRequestModel = new DialogNodeOutput()
            {
                Generic = DialogNodeOutputGeneric,
                Modifiers = DialogNodeOutputModifiersModel
            };

            Assert.IsTrue(testRequestModel.Generic == DialogNodeOutputGeneric);
            Assert.IsTrue(testRequestModel.Modifiers == DialogNodeOutputModifiersModel);
        }

        [TestMethod]
        public void TestDialogSuggestionOutputModel()
        {
            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            var DialogSuggestionResponseGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogSuggestionResponseGeneric DialogSuggestionResponseGenericModel = new DialogSuggestionResponseGeneric()
            {
                ResponseType = "text",
                Text = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogSuggestionResponseGenericOptions,
                MessageToHumanAgent = "testString",
                DialogNode = "testString"
            };

            DialogNodeVisitedDetails DialogNodeVisitedDetailsModel = new DialogNodeVisitedDetails()
            {
                DialogNode = "testString",
                Title = "testString",
                Conditions = "testString"
            };

            var DialogSuggestionOutputNodesVisited = new List<string> { "testString" };
            var DialogSuggestionOutputNodesVisitedDetails = new List<DialogNodeVisitedDetails> { DialogNodeVisitedDetailsModel };
            var DialogSuggestionOutputText = new List<string> { "testString" };
            var DialogSuggestionOutputGeneric = new List<DialogSuggestionResponseGeneric> { DialogSuggestionResponseGenericModel };
            DialogSuggestionOutput testRequestModel = new DialogSuggestionOutput()
            {
                NodesVisited = DialogSuggestionOutputNodesVisited,
                NodesVisitedDetails = DialogSuggestionOutputNodesVisitedDetails,
                Text = DialogSuggestionOutputText,
                Generic = DialogSuggestionOutputGeneric
            };

            Assert.IsTrue(testRequestModel.NodesVisited == DialogSuggestionOutputNodesVisited);
            Assert.IsTrue(testRequestModel.NodesVisitedDetails == DialogSuggestionOutputNodesVisitedDetails);
            Assert.IsTrue(testRequestModel.Text == DialogSuggestionOutputText);
            Assert.IsTrue(testRequestModel.Generic == DialogSuggestionOutputGeneric);
        }

        [TestMethod]
        public void TestMessageInputModel()
        {

            MessageInput testRequestModel = new MessageInput()
            {
                Text = "testString"
            };

            Assert.IsTrue(testRequestModel.Text == "testString");
        }

        [TestMethod]
        public void TestOutputDataModel()
        {
            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            var DialogSuggestionResponseGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogSuggestionResponseGeneric DialogSuggestionResponseGenericModel = new DialogSuggestionResponseGeneric()
            {
                ResponseType = "text",
                Text = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogSuggestionResponseGenericOptions,
                MessageToHumanAgent = "testString",
                DialogNode = "testString"
            };

            DialogNodeVisitedDetails DialogNodeVisitedDetailsModel = new DialogNodeVisitedDetails()
            {
                DialogNode = "testString",
                Title = "testString",
                Conditions = "testString"
            };

            var DialogSuggestionOutputNodesVisited = new List<string> { "testString" };
            var DialogSuggestionOutputNodesVisitedDetails = new List<DialogNodeVisitedDetails> { DialogNodeVisitedDetailsModel };
            var DialogSuggestionOutputText = new List<string> { "testString" };
            var DialogSuggestionOutputGeneric = new List<DialogSuggestionResponseGeneric> { DialogSuggestionResponseGenericModel };
            DialogSuggestionOutput DialogSuggestionOutputModel = new DialogSuggestionOutput()
            {
                NodesVisited = DialogSuggestionOutputNodesVisited,
                NodesVisitedDetails = DialogSuggestionOutputNodesVisitedDetails,
                Text = DialogSuggestionOutputText,
                Generic = DialogSuggestionOutputGeneric
            };

            var DialogSuggestionValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogSuggestionValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogSuggestionValue DialogSuggestionValueModel = new DialogSuggestionValue()
            {
                Input = MessageInputModel,
                Intents = DialogSuggestionValueIntents,
                Entities = DialogSuggestionValueEntities
            };

            DialogSuggestion DialogSuggestionModel = new DialogSuggestion()
            {
                Label = "testString",
                Value = DialogSuggestionValueModel,
                Output = DialogSuggestionOutputModel,
                DialogNode = "testString"
            };

            var RuntimeResponseGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            var RuntimeResponseGenericSuggestions = new List<DialogSuggestion> { DialogSuggestionModel };
            RuntimeResponseGeneric RuntimeResponseGenericModel = new RuntimeResponseGeneric()
            {
                ResponseType = "text",
                Text = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = RuntimeResponseGenericOptions,
                MessageToHumanAgent = "testString",
                DialogNode = "testString",
                Suggestions = RuntimeResponseGenericSuggestions
            };

            LogMessage LogMessageModel = new LogMessage()
            {
                Level = "info",
                Msg = "testString"
            };

            var OutputDataNodesVisited = new List<string> { "testString" };
            var OutputDataNodesVisitedDetails = new List<DialogNodeVisitedDetails> { DialogNodeVisitedDetailsModel };
            var OutputDataLogMessages = new List<LogMessage> { LogMessageModel };
            var OutputDataText = new List<string> { "testString" };
            var OutputDataGeneric = new List<RuntimeResponseGeneric> { RuntimeResponseGenericModel };
            OutputData testRequestModel = new OutputData()
            {
                NodesVisited = OutputDataNodesVisited,
                NodesVisitedDetails = OutputDataNodesVisitedDetails,
                LogMessages = OutputDataLogMessages,
                Text = OutputDataText,
                Generic = OutputDataGeneric
            };

            Assert.IsTrue(testRequestModel.NodesVisited == OutputDataNodesVisited);
            Assert.IsTrue(testRequestModel.NodesVisitedDetails == OutputDataNodesVisitedDetails);
            Assert.IsTrue(testRequestModel.LogMessages == OutputDataLogMessages);
            Assert.IsTrue(testRequestModel.Text == OutputDataText);
            Assert.IsTrue(testRequestModel.Generic == OutputDataGeneric);
        }

        [TestMethod]
        public void TestSystemResponseModel()
        {

            SystemResponse testRequestModel = new SystemResponse()
            {
            };

        }

        [TestMethod]
        public void TestTestMessageAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}], 'alternate_intents': true, 'context': {'conversation_id': 'ConversationId', 'system': {}, 'metadata': {'deployment': 'Deployment', 'user_id': 'UserId'}}, 'output': {'nodes_visited': ['NodesVisited'], 'nodes_visited_details': [{'dialog_node': 'DialogNode', 'title': 'Title', 'conditions': 'Conditions'}], 'log_messages': [{'level': 'info', 'msg': 'Msg'}], 'text': ['Text'], 'generic': [{'response_type': 'text', 'text': 'Text', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'topic': 'Topic', 'dialog_node': 'DialogNode', 'suggestions': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}, 'output': {'nodes_visited': ['NodesVisited'], 'nodes_visited_details': [{'dialog_node': 'DialogNode', 'title': 'Title', 'conditions': 'Conditions'}], 'text': ['Text'], 'generic': [{'response_type': 'text', 'text': 'Text', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'topic': 'Topic', 'dialog_node': 'DialogNode'}]}, 'dialog_node': 'DialogNode'}]}]}, 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}]}";
            var response = new DetailedResponse<MessageResponse>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<MessageResponse>(responseJson),
                StatusCode = 200
            };

            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            var DialogSuggestionResponseGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogSuggestionResponseGeneric DialogSuggestionResponseGenericModel = new DialogSuggestionResponseGeneric()
            {
                ResponseType = "text",
                Text = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogSuggestionResponseGenericOptions,
                MessageToHumanAgent = "testString",
                DialogNode = "testString"
            };

            DialogNodeVisitedDetails DialogNodeVisitedDetailsModel = new DialogNodeVisitedDetails()
            {
                DialogNode = "testString",
                Title = "testString",
                Conditions = "testString"
            };

            var DialogSuggestionOutputNodesVisited = new List<string> { "testString" };
            var DialogSuggestionOutputNodesVisitedDetails = new List<DialogNodeVisitedDetails> { DialogNodeVisitedDetailsModel };
            var DialogSuggestionOutputText = new List<string> { "testString" };
            var DialogSuggestionOutputGeneric = new List<DialogSuggestionResponseGeneric> { DialogSuggestionResponseGenericModel };
            DialogSuggestionOutput DialogSuggestionOutputModel = new DialogSuggestionOutput()
            {
                NodesVisited = DialogSuggestionOutputNodesVisited,
                NodesVisitedDetails = DialogSuggestionOutputNodesVisitedDetails,
                Text = DialogSuggestionOutputText,
                Generic = DialogSuggestionOutputGeneric
            };

            var DialogSuggestionValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogSuggestionValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogSuggestionValue DialogSuggestionValueModel = new DialogSuggestionValue()
            {
                Input = MessageInputModel,
                Intents = DialogSuggestionValueIntents,
                Entities = DialogSuggestionValueEntities
            };

            DialogSuggestion DialogSuggestionModel = new DialogSuggestion()
            {
                Label = "testString",
                Value = DialogSuggestionValueModel,
                Output = DialogSuggestionOutputModel,
                DialogNode = "testString"
            };

            var RuntimeResponseGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            var RuntimeResponseGenericSuggestions = new List<DialogSuggestion> { DialogSuggestionModel };
            RuntimeResponseGeneric RuntimeResponseGenericModel = new RuntimeResponseGeneric()
            {
                ResponseType = "text",
                Text = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = RuntimeResponseGenericOptions,
                MessageToHumanAgent = "testString",
                DialogNode = "testString",
                Suggestions = RuntimeResponseGenericSuggestions
            };

            LogMessage LogMessageModel = new LogMessage()
            {
                Level = "info",
                Msg = "testString"
            };

            var OutputDataNodesVisited = new List<string> { "testString" };
            var OutputDataNodesVisitedDetails = new List<DialogNodeVisitedDetails> { DialogNodeVisitedDetailsModel };
            var OutputDataLogMessages = new List<LogMessage> { LogMessageModel };
            var OutputDataText = new List<string> { "testString" };
            var OutputDataGeneric = new List<RuntimeResponseGeneric> { RuntimeResponseGenericModel };
            OutputData OutputDataModel = new OutputData()
            {
                NodesVisited = OutputDataNodesVisited,
                NodesVisitedDetails = OutputDataNodesVisitedDetails,
                LogMessages = OutputDataLogMessages,
                Text = OutputDataText,
                Generic = OutputDataGeneric
            };

            MessageContextMetadata MessageContextMetadataModel = new MessageContextMetadata()
            {
                Deployment = "testString",
                UserId = "testString"
            };

            SystemResponse SystemResponseModel = new SystemResponse()
            {
            };

            Context ContextModel = new Context()
            {
                ConversationId = "testString",
                System = SystemResponseModel,
                Metadata = MessageContextMetadataModel
            };
            string workspaceId = "testString";
            bool? nodesVisitedDetails = true;

            request.As<MessageResponse>().Returns(Task.FromResult(response));

            var result = service.Message(workspaceId: workspaceId, input: MessageInputModel, intents: new List<RuntimeIntent> { RuntimeIntentModel }, entities: new List<RuntimeEntity> { RuntimeEntityModel }, alternateIntents: true, context: ContextModel, output: OutputDataModel, nodesVisitedDetails: nodesVisitedDetails);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/message";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestListWorkspacesAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'workspaces': [{'name': 'Name', 'description': 'Description', 'language': 'Language', 'metadata': {}, 'learning_opt_out': true, 'system_settings': {'tooling': {'store_generic_responses': false}, 'disambiguation': {'prompt': 'Prompt', 'none_of_the_above_prompt': 'NoneOfTheAbovePrompt', 'enabled': false, 'sensitivity': 'auto', 'randomize': false, 'max_suggestions': 14, 'suggestion_text_policy': 'SuggestionTextPolicy'}, 'human_agent_assist': {}, 'off_topic': {'enabled': false}}, 'workspace_id': 'WorkspaceId', 'status': 'Non Existent', 'intents': [{'intent': '_Intent', 'description': 'Description', 'examples': [{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}]}], 'entities': [{'entity': '_Entity', 'description': 'Description', 'metadata': {}, 'fuzzy_match': true, 'values': [{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}]}], 'dialog_nodes': [{'dialog_node': '_DialogNode', 'description': 'Description', 'conditions': 'Conditions', 'parent': 'Parent', 'previous_sibling': 'PreviousSibling', 'output': {'generic': [{'response_type': 'text', 'values': [{'text': 'Text'}], 'selection_policy': 'sequential', 'delimiter': 'Delimiter', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'query': 'Query', 'query_type': 'natural_language', 'filter': 'Filter', 'discovery_version': 'DiscoveryVersion'}], 'modifiers': {'overwrite': false}}, 'context': {}, 'metadata': {}, 'next_step': {'behavior': 'get_user_input', 'dialog_node': 'DialogNode', 'selector': 'condition'}, 'title': 'Title', 'type': 'standard', 'event_name': 'focus', 'variable': 'Variable', 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}], 'digress_in': 'not_available', 'digress_out': 'allow_returning', 'digress_out_slots': 'not_allowed', 'user_label': 'UserLabel', 'disambiguation_opt_out': true, 'disabled': true}], 'counterexamples': [{'text': 'Text'}], 'webhooks': [{'url': 'Url', 'name': 'Name', 'headers': [{'name': 'Name', 'value': 'Value'}]}]}], 'pagination': {'refresh_url': 'RefreshUrl', 'next_url': 'NextUrl', 'total': 5, 'matched': 7, 'refresh_cursor': 'RefreshCursor', 'next_cursor': 'NextCursor'}}";
            var response = new DetailedResponse<WorkspaceCollection>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<WorkspaceCollection>(responseJson),
                StatusCode = 200
            };

            long? pageLimit = 38;
            string sort = "name";
            string cursor = "testString";
            bool? includeAudit = true;

            request.As<WorkspaceCollection>().Returns(Task.FromResult(response));

            var result = service.ListWorkspaces(pageLimit: pageLimit, sort: sort, cursor: cursor, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestCreateWorkspaceAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'name': 'Name', 'description': 'Description', 'language': 'Language', 'metadata': {}, 'learning_opt_out': true, 'system_settings': {'tooling': {'store_generic_responses': false}, 'disambiguation': {'prompt': 'Prompt', 'none_of_the_above_prompt': 'NoneOfTheAbovePrompt', 'enabled': false, 'sensitivity': 'auto', 'randomize': false, 'max_suggestions': 14, 'suggestion_text_policy': 'SuggestionTextPolicy'}, 'human_agent_assist': {}, 'off_topic': {'enabled': false}}, 'workspace_id': 'WorkspaceId', 'status': 'Non Existent', 'intents': [{'intent': '_Intent', 'description': 'Description', 'examples': [{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}]}], 'entities': [{'entity': '_Entity', 'description': 'Description', 'metadata': {}, 'fuzzy_match': true, 'values': [{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}]}], 'dialog_nodes': [{'dialog_node': '_DialogNode', 'description': 'Description', 'conditions': 'Conditions', 'parent': 'Parent', 'previous_sibling': 'PreviousSibling', 'output': {'generic': [{'response_type': 'text', 'values': [{'text': 'Text'}], 'selection_policy': 'sequential', 'delimiter': 'Delimiter', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'query': 'Query', 'query_type': 'natural_language', 'filter': 'Filter', 'discovery_version': 'DiscoveryVersion'}], 'modifiers': {'overwrite': false}}, 'context': {}, 'metadata': {}, 'next_step': {'behavior': 'get_user_input', 'dialog_node': 'DialogNode', 'selector': 'condition'}, 'title': 'Title', 'type': 'standard', 'event_name': 'focus', 'variable': 'Variable', 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}], 'digress_in': 'not_available', 'digress_out': 'allow_returning', 'digress_out_slots': 'not_allowed', 'user_label': 'UserLabel', 'disambiguation_opt_out': true, 'disabled': true}], 'counterexamples': [{'text': 'Text'}], 'webhooks': [{'url': 'Url', 'name': 'Name', 'headers': [{'name': 'Name', 'value': 'Value'}]}]}";
            var response = new DetailedResponse<Workspace>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Workspace>(responseJson),
                StatusCode = 201
            };

            WebhookHeader WebhookHeaderModel = new WebhookHeader()
            {
                Name = "testString",
                Value = "testString"
            };

            var WebhookHeaders = new List<WebhookHeader> { WebhookHeaderModel };
            Webhook WebhookModel = new Webhook()
            {
                Url = "testString",
                Name = "testString",
                Headers = WebhookHeaders
            };

            Counterexample CounterexampleModel = new Counterexample()
            {
                Text = "testString",
            };

            var DialogNodeActionParameters = new Dictionary<string, object>();
            DialogNodeAction DialogNodeActionModel = new DialogNodeAction()
            {
                Name = "testString",
                Type = "client",
                Parameters = DialogNodeActionParameters,
                ResultVariable = "testString",
                Credentials = "testString"
            };

            DialogNodeNextStep DialogNodeNextStepModel = new DialogNodeNextStep()
            {
                Behavior = "get_user_input",
                DialogNode = "testString",
                Selector = "condition"
            };

            DialogNodeOutputModifiers DialogNodeOutputModifiersModel = new DialogNodeOutputModifiers()
            {
                Overwrite = true
            };

            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            DialogNodeOutputTextValuesElement DialogNodeOutputTextValuesElementModel = new DialogNodeOutputTextValuesElement()
            {
                Text = "testString"
            };

            var DialogNodeOutputGenericValues = new List<DialogNodeOutputTextValuesElement> { DialogNodeOutputTextValuesElementModel };
            var DialogNodeOutputGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogNodeOutputGeneric DialogNodeOutputGenericModel = new DialogNodeOutputGeneric()
            {
                ResponseType = "text",
                Values = DialogNodeOutputGenericValues,
                SelectionPolicy = "sequential",
                Delimiter = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogNodeOutputGenericOptions,
                MessageToHumanAgent = "testString",
                Query = "testString",
                QueryType = "natural_language",
                Filter = "testString",
                DiscoveryVersion = "testString"
            };

            var DialogNodeOutputGeneric = new List<DialogNodeOutputGeneric> { DialogNodeOutputGenericModel };
            DialogNodeOutput DialogNodeOutputModel = new DialogNodeOutput()
            {
                Generic = DialogNodeOutputGeneric,
                Modifiers = DialogNodeOutputModifiersModel
            };

            var DialogNodeContext = new Dictionary<string, object>();
            var DialogNodeMetadata = new Dictionary<string, object>();
            var DialogNodeActions = new List<DialogNodeAction> { DialogNodeActionModel };
            DialogNode DialogNodeModel = new DialogNode()
            {
                _DialogNode = "testString",
                Description = "testString",
                Conditions = "testString",
                Parent = "testString",
                PreviousSibling = "testString",
                Output = DialogNodeOutputModel,
                Context = DialogNodeContext,
                Metadata = DialogNodeMetadata,
                NextStep = DialogNodeNextStepModel,
                Title = "testString",
                Type = "standard",
                EventName = "focus",
                Variable = "testString",
                Actions = DialogNodeActions,
                DigressIn = "not_available",
                DigressOut = "allow_returning",
                DigressOutSlots = "not_allowed",
                UserLabel = "testString",
                DisambiguationOptOut = true,
            };

            var CreateValueMetadata = new Dictionary<string, object>();
            var CreateValueSynonyms = new List<string> { "testString" };
            var CreateValuePatterns = new List<string> { "testString" };
            CreateValue CreateValueModel = new CreateValue()
            {
                Value = "testString",
                Metadata = CreateValueMetadata,
                Type = "synonyms",
                Synonyms = CreateValueSynonyms,
                Patterns = CreateValuePatterns,
            };

            var CreateEntityMetadata = new Dictionary<string, object>();
            var CreateEntityValues = new List<CreateValue> { CreateValueModel };
            CreateEntity CreateEntityModel = new CreateEntity()
            {
                Entity = "testString",
                Description = "testString",
                Metadata = CreateEntityMetadata,
                FuzzyMatch = true,
                Values = CreateEntityValues
            };

            var MentionLocation = new List<long?> { 38 };
            Mention MentionModel = new Mention()
            {
                Entity = "testString",
                Location = MentionLocation
            };

            var ExampleMentions = new List<Mention> { MentionModel };
            Example ExampleModel = new Example()
            {
                Text = "testString",
                Mentions = ExampleMentions,
            };

            var CreateIntentExamples = new List<Example> { ExampleModel };
            CreateIntent CreateIntentModel = new CreateIntent()
            {
                Intent = "testString",
                Description = "testString",
                Examples = CreateIntentExamples
            };

            WorkspaceSystemSettingsOffTopic WorkspaceSystemSettingsOffTopicModel = new WorkspaceSystemSettingsOffTopic()
            {
                Enabled = true
            };

            WorkspaceSystemSettingsDisambiguation WorkspaceSystemSettingsDisambiguationModel = new WorkspaceSystemSettingsDisambiguation()
            {
                Prompt = "testString",
                NoneOfTheAbovePrompt = "testString",
                Enabled = true,
                Sensitivity = "auto",
                Randomize = true,
                MaxSuggestions = 38,
                SuggestionTextPolicy = "testString"
            };

            WorkspaceSystemSettingsTooling WorkspaceSystemSettingsToolingModel = new WorkspaceSystemSettingsTooling()
            {
                StoreGenericResponses = true
            };

            var WorkspaceSystemSettingsHumanAgentAssist = new Dictionary<string, object>();
            WorkspaceSystemSettings WorkspaceSystemSettingsModel = new WorkspaceSystemSettings()
            {
                Tooling = WorkspaceSystemSettingsToolingModel,
                Disambiguation = WorkspaceSystemSettingsDisambiguationModel,
                HumanAgentAssist = WorkspaceSystemSettingsHumanAgentAssist,
                OffTopic = WorkspaceSystemSettingsOffTopicModel
            };

            request.As<Workspace>().Returns(Task.FromResult(response));

            var result = service.CreateWorkspace(name: "testString", description: "testString", language: "testString", metadata: new Dictionary<string, object>(), learningOptOut: true, systemSettings: WorkspaceSystemSettingsModel, intents: new List<CreateIntent> { CreateIntentModel }, entities: new List<CreateEntity> { CreateEntityModel }, dialogNodes: new List<DialogNode> { DialogNodeModel }, counterexamples: new List<Counterexample> { CounterexampleModel }, webhooks: new List<Webhook> { WebhookModel });

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestGetWorkspaceAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'name': 'Name', 'description': 'Description', 'language': 'Language', 'metadata': {}, 'learning_opt_out': true, 'system_settings': {'tooling': {'store_generic_responses': false}, 'disambiguation': {'prompt': 'Prompt', 'none_of_the_above_prompt': 'NoneOfTheAbovePrompt', 'enabled': false, 'sensitivity': 'auto', 'randomize': false, 'max_suggestions': 14, 'suggestion_text_policy': 'SuggestionTextPolicy'}, 'human_agent_assist': {}, 'off_topic': {'enabled': false}}, 'workspace_id': 'WorkspaceId', 'status': 'Non Existent', 'intents': [{'intent': '_Intent', 'description': 'Description', 'examples': [{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}]}], 'entities': [{'entity': '_Entity', 'description': 'Description', 'metadata': {}, 'fuzzy_match': true, 'values': [{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}]}], 'dialog_nodes': [{'dialog_node': '_DialogNode', 'description': 'Description', 'conditions': 'Conditions', 'parent': 'Parent', 'previous_sibling': 'PreviousSibling', 'output': {'generic': [{'response_type': 'text', 'values': [{'text': 'Text'}], 'selection_policy': 'sequential', 'delimiter': 'Delimiter', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'query': 'Query', 'query_type': 'natural_language', 'filter': 'Filter', 'discovery_version': 'DiscoveryVersion'}], 'modifiers': {'overwrite': false}}, 'context': {}, 'metadata': {}, 'next_step': {'behavior': 'get_user_input', 'dialog_node': 'DialogNode', 'selector': 'condition'}, 'title': 'Title', 'type': 'standard', 'event_name': 'focus', 'variable': 'Variable', 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}], 'digress_in': 'not_available', 'digress_out': 'allow_returning', 'digress_out_slots': 'not_allowed', 'user_label': 'UserLabel', 'disambiguation_opt_out': true, 'disabled': true}], 'counterexamples': [{'text': 'Text'}], 'webhooks': [{'url': 'Url', 'name': 'Name', 'headers': [{'name': 'Name', 'value': 'Value'}]}]}";
            var response = new DetailedResponse<Workspace>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Workspace>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            bool? export = true;
            bool? includeAudit = true;
            string sort = "stable";

            request.As<Workspace>().Returns(Task.FromResult(response));

            var result = service.GetWorkspace(workspaceId: workspaceId, export: export, includeAudit: includeAudit, sort: sort);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestUpdateWorkspaceAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'name': 'Name', 'description': 'Description', 'language': 'Language', 'metadata': {}, 'learning_opt_out': true, 'system_settings': {'tooling': {'store_generic_responses': false}, 'disambiguation': {'prompt': 'Prompt', 'none_of_the_above_prompt': 'NoneOfTheAbovePrompt', 'enabled': false, 'sensitivity': 'auto', 'randomize': false, 'max_suggestions': 14, 'suggestion_text_policy': 'SuggestionTextPolicy'}, 'human_agent_assist': {}, 'off_topic': {'enabled': false}}, 'workspace_id': 'WorkspaceId', 'status': 'Non Existent', 'intents': [{'intent': '_Intent', 'description': 'Description', 'examples': [{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}]}], 'entities': [{'entity': '_Entity', 'description': 'Description', 'metadata': {}, 'fuzzy_match': true, 'values': [{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}]}], 'dialog_nodes': [{'dialog_node': '_DialogNode', 'description': 'Description', 'conditions': 'Conditions', 'parent': 'Parent', 'previous_sibling': 'PreviousSibling', 'output': {'generic': [{'response_type': 'text', 'values': [{'text': 'Text'}], 'selection_policy': 'sequential', 'delimiter': 'Delimiter', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'query': 'Query', 'query_type': 'natural_language', 'filter': 'Filter', 'discovery_version': 'DiscoveryVersion'}], 'modifiers': {'overwrite': false}}, 'context': {}, 'metadata': {}, 'next_step': {'behavior': 'get_user_input', 'dialog_node': 'DialogNode', 'selector': 'condition'}, 'title': 'Title', 'type': 'standard', 'event_name': 'focus', 'variable': 'Variable', 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}], 'digress_in': 'not_available', 'digress_out': 'allow_returning', 'digress_out_slots': 'not_allowed', 'user_label': 'UserLabel', 'disambiguation_opt_out': true, 'disabled': true}], 'counterexamples': [{'text': 'Text'}], 'webhooks': [{'url': 'Url', 'name': 'Name', 'headers': [{'name': 'Name', 'value': 'Value'}]}]}";
            var response = new DetailedResponse<Workspace>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Workspace>(responseJson),
                StatusCode = 200
            };

            WebhookHeader WebhookHeaderModel = new WebhookHeader()
            {
                Name = "testString",
                Value = "testString"
            };

            var WebhookHeaders = new List<WebhookHeader> { WebhookHeaderModel };
            Webhook WebhookModel = new Webhook()
            {
                Url = "testString",
                Name = "testString",
                Headers = WebhookHeaders
            };

            Counterexample CounterexampleModel = new Counterexample()
            {
                Text = "testString",
            };

            var DialogNodeActionParameters = new Dictionary<string, object>();
            DialogNodeAction DialogNodeActionModel = new DialogNodeAction()
            {
                Name = "testString",
                Type = "client",
                Parameters = DialogNodeActionParameters,
                ResultVariable = "testString",
                Credentials = "testString"
            };

            DialogNodeNextStep DialogNodeNextStepModel = new DialogNodeNextStep()
            {
                Behavior = "get_user_input",
                DialogNode = "testString",
                Selector = "condition"
            };

            DialogNodeOutputModifiers DialogNodeOutputModifiersModel = new DialogNodeOutputModifiers()
            {
                Overwrite = true
            };

            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            DialogNodeOutputTextValuesElement DialogNodeOutputTextValuesElementModel = new DialogNodeOutputTextValuesElement()
            {
                Text = "testString"
            };

            var DialogNodeOutputGenericValues = new List<DialogNodeOutputTextValuesElement> { DialogNodeOutputTextValuesElementModel };
            var DialogNodeOutputGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogNodeOutputGeneric DialogNodeOutputGenericModel = new DialogNodeOutputGeneric()
            {
                ResponseType = "text",
                Values = DialogNodeOutputGenericValues,
                SelectionPolicy = "sequential",
                Delimiter = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogNodeOutputGenericOptions,
                MessageToHumanAgent = "testString",
                Query = "testString",
                QueryType = "natural_language",
                Filter = "testString",
                DiscoveryVersion = "testString"
            };

            var DialogNodeOutputGeneric = new List<DialogNodeOutputGeneric> { DialogNodeOutputGenericModel };
            DialogNodeOutput DialogNodeOutputModel = new DialogNodeOutput()
            {
                Generic = DialogNodeOutputGeneric,
                Modifiers = DialogNodeOutputModifiersModel
            };

            var DialogNodeContext = new Dictionary<string, object>();
            var DialogNodeMetadata = new Dictionary<string, object>();
            var DialogNodeActions = new List<DialogNodeAction> { DialogNodeActionModel };
            DialogNode DialogNodeModel = new DialogNode()
            {
                _DialogNode = "testString",
                Description = "testString",
                Conditions = "testString",
                Parent = "testString",
                PreviousSibling = "testString",
                Output = DialogNodeOutputModel,
                Context = DialogNodeContext,
                Metadata = DialogNodeMetadata,
                NextStep = DialogNodeNextStepModel,
                Title = "testString",
                Type = "standard",
                EventName = "focus",
                Variable = "testString",
                Actions = DialogNodeActions,
                DigressIn = "not_available",
                DigressOut = "allow_returning",
                DigressOutSlots = "not_allowed",
                UserLabel = "testString",
                DisambiguationOptOut = true,
            };

            var CreateValueMetadata = new Dictionary<string, object>();
            var CreateValueSynonyms = new List<string> { "testString" };
            var CreateValuePatterns = new List<string> { "testString" };
            CreateValue CreateValueModel = new CreateValue()
            {
                Value = "testString",
                Metadata = CreateValueMetadata,
                Type = "synonyms",
                Synonyms = CreateValueSynonyms,
                Patterns = CreateValuePatterns,
            };

            var CreateEntityMetadata = new Dictionary<string, object>();
            var CreateEntityValues = new List<CreateValue> { CreateValueModel };
            CreateEntity CreateEntityModel = new CreateEntity()
            {
                Entity = "testString",
                Description = "testString",
                Metadata = CreateEntityMetadata,
                FuzzyMatch = true,
                Values = CreateEntityValues
            };

            var MentionLocation = new List<long?> { 38 };
            Mention MentionModel = new Mention()
            {
                Entity = "testString",
                Location = MentionLocation
            };

            var ExampleMentions = new List<Mention> { MentionModel };
            Example ExampleModel = new Example()
            {
                Text = "testString",
                Mentions = ExampleMentions,
            };

            var CreateIntentExamples = new List<Example> { ExampleModel };
            CreateIntent CreateIntentModel = new CreateIntent()
            {
                Intent = "testString",
                Description = "testString",
                Examples = CreateIntentExamples
            };

            WorkspaceSystemSettingsOffTopic WorkspaceSystemSettingsOffTopicModel = new WorkspaceSystemSettingsOffTopic()
            {
                Enabled = true
            };

            WorkspaceSystemSettingsDisambiguation WorkspaceSystemSettingsDisambiguationModel = new WorkspaceSystemSettingsDisambiguation()
            {
                Prompt = "testString",
                NoneOfTheAbovePrompt = "testString",
                Enabled = true,
                Sensitivity = "auto",
                Randomize = true,
                MaxSuggestions = 38,
                SuggestionTextPolicy = "testString"
            };

            WorkspaceSystemSettingsTooling WorkspaceSystemSettingsToolingModel = new WorkspaceSystemSettingsTooling()
            {
                StoreGenericResponses = true
            };

            var WorkspaceSystemSettingsHumanAgentAssist = new Dictionary<string, object>();
            WorkspaceSystemSettings WorkspaceSystemSettingsModel = new WorkspaceSystemSettings()
            {
                Tooling = WorkspaceSystemSettingsToolingModel,
                Disambiguation = WorkspaceSystemSettingsDisambiguationModel,
                HumanAgentAssist = WorkspaceSystemSettingsHumanAgentAssist,
                OffTopic = WorkspaceSystemSettingsOffTopicModel
            };
            string workspaceId = "testString";
            bool? append = true;

            request.As<Workspace>().Returns(Task.FromResult(response));

            var result = service.UpdateWorkspace(workspaceId: workspaceId, name: "testString", description: "testString", language: "testString", metadata: new Dictionary<string, object>(), learningOptOut: true, systemSettings: WorkspaceSystemSettingsModel, intents: new List<CreateIntent> { CreateIntentModel }, entities: new List<CreateEntity> { CreateEntityModel }, dialogNodes: new List<DialogNode> { DialogNodeModel }, counterexamples: new List<Counterexample> { CounterexampleModel }, webhooks: new List<Webhook> { WebhookModel }, append: append);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestDeleteWorkspaceAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.DeleteAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var response = new DetailedResponse<object>()
            {
                Result = new object(),
                StatusCode = 200
            };

            string workspaceId = "testString";

            request.As<object>().Returns(Task.FromResult(response));

            var result = service.DeleteWorkspace(workspaceId: workspaceId);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}";
            client.Received().DeleteAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestListIntentsAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'intents': [{'intent': '_Intent', 'description': 'Description', 'examples': [{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}]}], 'pagination': {'refresh_url': 'RefreshUrl', 'next_url': 'NextUrl', 'total': 5, 'matched': 7, 'refresh_cursor': 'RefreshCursor', 'next_cursor': 'NextCursor'}}";
            var response = new DetailedResponse<IntentCollection>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<IntentCollection>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            bool? export = true;
            long? pageLimit = 38;
            string sort = "intent";
            string cursor = "testString";
            bool? includeAudit = true;

            request.As<IntentCollection>().Returns(Task.FromResult(response));

            var result = service.ListIntents(workspaceId: workspaceId, export: export, pageLimit: pageLimit, sort: sort, cursor: cursor, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/intents";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestCreateIntentAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'intent': '_Intent', 'description': 'Description', 'examples': [{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}]}";
            var response = new DetailedResponse<Intent>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Intent>(responseJson),
                StatusCode = 201
            };

            var MentionLocation = new List<long?> { 38 };
            Mention MentionModel = new Mention()
            {
                Entity = "testString",
                Location = MentionLocation
            };

            var ExampleMentions = new List<Mention> { MentionModel };
            Example ExampleModel = new Example()
            {
                Text = "testString",
                Mentions = ExampleMentions,
            };
            string workspaceId = "testString";

            request.As<Intent>().Returns(Task.FromResult(response));

            var result = service.CreateIntent(workspaceId: workspaceId, intent: "testString", description: "testString", examples: new List<Example> { ExampleModel });

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/intents";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestGetIntentAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'intent': '_Intent', 'description': 'Description', 'examples': [{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}]}";
            var response = new DetailedResponse<Intent>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Intent>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string intent = "testString";
            bool? export = true;
            bool? includeAudit = true;

            request.As<Intent>().Returns(Task.FromResult(response));

            var result = service.GetIntent(workspaceId: workspaceId, intent: intent, export: export, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/intents/{intent}";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestUpdateIntentAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'intent': '_Intent', 'description': 'Description', 'examples': [{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}]}";
            var response = new DetailedResponse<Intent>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Intent>(responseJson),
                StatusCode = 200
            };

            var MentionLocation = new List<long?> { 38 };
            Mention MentionModel = new Mention()
            {
                Entity = "testString",
                Location = MentionLocation
            };

            var ExampleMentions = new List<Mention> { MentionModel };
            Example ExampleModel = new Example()
            {
                Text = "testString",
                Mentions = ExampleMentions,
            };
            string workspaceId = "testString";
            string intent = "testString";

            request.As<Intent>().Returns(Task.FromResult(response));

            var result = service.UpdateIntent(workspaceId: workspaceId, intent: intent, newIntent: "testString", newDescription: "testString", newExamples: new List<Example> { ExampleModel });

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/intents/{intent}";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestDeleteIntentAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.DeleteAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var response = new DetailedResponse<object>()
            {
                Result = new object(),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string intent = "testString";

            request.As<object>().Returns(Task.FromResult(response));

            var result = service.DeleteIntent(workspaceId: workspaceId, intent: intent);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/intents/{intent}";
            client.Received().DeleteAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestListExamplesAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'examples': [{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}], 'pagination': {'refresh_url': 'RefreshUrl', 'next_url': 'NextUrl', 'total': 5, 'matched': 7, 'refresh_cursor': 'RefreshCursor', 'next_cursor': 'NextCursor'}}";
            var response = new DetailedResponse<ExampleCollection>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<ExampleCollection>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string intent = "testString";
            long? pageLimit = 38;
            string sort = "text";
            string cursor = "testString";
            bool? includeAudit = true;

            request.As<ExampleCollection>().Returns(Task.FromResult(response));

            var result = service.ListExamples(workspaceId: workspaceId, intent: intent, pageLimit: pageLimit, sort: sort, cursor: cursor, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/intents/{intent}/examples";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestCreateExampleAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}";
            var response = new DetailedResponse<Example>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Example>(responseJson),
                StatusCode = 201
            };

            var MentionLocation = new List<long?> { 38 };
            Mention MentionModel = new Mention()
            {
                Entity = "testString",
                Location = MentionLocation
            };
            string workspaceId = "testString";
            string intent = "testString";

            request.As<Example>().Returns(Task.FromResult(response));

            var result = service.CreateExample(workspaceId: workspaceId, intent: intent, text: "testString", mentions: new List<Mention> { MentionModel });

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/intents/{intent}/examples";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestGetExampleAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}";
            var response = new DetailedResponse<Example>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Example>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string intent = "testString";
            string text = "testString";
            bool? includeAudit = true;

            request.As<Example>().Returns(Task.FromResult(response));

            var result = service.GetExample(workspaceId: workspaceId, intent: intent, text: text, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/intents/{intent}/examples/{text}";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestUpdateExampleAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'text': 'Text', 'mentions': [{'entity': 'Entity', 'location': [8]}]}";
            var response = new DetailedResponse<Example>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Example>(responseJson),
                StatusCode = 200
            };

            var MentionLocation = new List<long?> { 38 };
            Mention MentionModel = new Mention()
            {
                Entity = "testString",
                Location = MentionLocation
            };
            string workspaceId = "testString";
            string intent = "testString";
            string text = "testString";

            request.As<Example>().Returns(Task.FromResult(response));

            var result = service.UpdateExample(workspaceId: workspaceId, intent: intent, text: text, newText: "testString", newMentions: new List<Mention> { MentionModel });

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/intents/{intent}/examples/{text}";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestDeleteExampleAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.DeleteAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var response = new DetailedResponse<object>()
            {
                Result = new object(),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string intent = "testString";
            string text = "testString";

            request.As<object>().Returns(Task.FromResult(response));

            var result = service.DeleteExample(workspaceId: workspaceId, intent: intent, text: text);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/intents/{intent}/examples/{text}";
            client.Received().DeleteAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestListCounterexamplesAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'counterexamples': [{'text': 'Text'}], 'pagination': {'refresh_url': 'RefreshUrl', 'next_url': 'NextUrl', 'total': 5, 'matched': 7, 'refresh_cursor': 'RefreshCursor', 'next_cursor': 'NextCursor'}}";
            var response = new DetailedResponse<CounterexampleCollection>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<CounterexampleCollection>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            long? pageLimit = 38;
            string sort = "text";
            string cursor = "testString";
            bool? includeAudit = true;

            request.As<CounterexampleCollection>().Returns(Task.FromResult(response));

            var result = service.ListCounterexamples(workspaceId: workspaceId, pageLimit: pageLimit, sort: sort, cursor: cursor, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/counterexamples";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestCreateCounterexampleAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'text': 'Text'}";
            var response = new DetailedResponse<Counterexample>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Counterexample>(responseJson),
                StatusCode = 201
            };

            string workspaceId = "testString";

            request.As<Counterexample>().Returns(Task.FromResult(response));

            var result = service.CreateCounterexample(workspaceId: workspaceId, text: "testString");

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/counterexamples";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestGetCounterexampleAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'text': 'Text'}";
            var response = new DetailedResponse<Counterexample>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Counterexample>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string text = "testString";
            bool? includeAudit = true;

            request.As<Counterexample>().Returns(Task.FromResult(response));

            var result = service.GetCounterexample(workspaceId: workspaceId, text: text, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/counterexamples/{text}";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestUpdateCounterexampleAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'text': 'Text'}";
            var response = new DetailedResponse<Counterexample>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Counterexample>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string text = "testString";

            request.As<Counterexample>().Returns(Task.FromResult(response));

            var result = service.UpdateCounterexample(workspaceId: workspaceId, text: text, newText: "testString");

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/counterexamples/{text}";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestDeleteCounterexampleAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.DeleteAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var response = new DetailedResponse<object>()
            {
                Result = new object(),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string text = "testString";

            request.As<object>().Returns(Task.FromResult(response));

            var result = service.DeleteCounterexample(workspaceId: workspaceId, text: text);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/counterexamples/{text}";
            client.Received().DeleteAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestListEntitiesAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'entities': [{'entity': '_Entity', 'description': 'Description', 'metadata': {}, 'fuzzy_match': true, 'values': [{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}]}], 'pagination': {'refresh_url': 'RefreshUrl', 'next_url': 'NextUrl', 'total': 5, 'matched': 7, 'refresh_cursor': 'RefreshCursor', 'next_cursor': 'NextCursor'}}";
            var response = new DetailedResponse<EntityCollection>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<EntityCollection>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            bool? export = true;
            long? pageLimit = 38;
            string sort = "entity";
            string cursor = "testString";
            bool? includeAudit = true;

            request.As<EntityCollection>().Returns(Task.FromResult(response));

            var result = service.ListEntities(workspaceId: workspaceId, export: export, pageLimit: pageLimit, sort: sort, cursor: cursor, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestCreateEntityAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'entity': '_Entity', 'description': 'Description', 'metadata': {}, 'fuzzy_match': true, 'values': [{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}]}";
            var response = new DetailedResponse<Entity>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Entity>(responseJson),
                StatusCode = 201
            };

            var CreateValueMetadata = new Dictionary<string, object>();
            var CreateValueSynonyms = new List<string> { "testString" };
            var CreateValuePatterns = new List<string> { "testString" };
            CreateValue CreateValueModel = new CreateValue()
            {
                Value = "testString",
                Metadata = CreateValueMetadata,
                Type = "synonyms",
                Synonyms = CreateValueSynonyms,
                Patterns = CreateValuePatterns,
            };
            string workspaceId = "testString";

            request.As<Entity>().Returns(Task.FromResult(response));

            var result = service.CreateEntity(workspaceId: workspaceId, entity: "testString", description: "testString", metadata: new Dictionary<string, object>(), fuzzyMatch: true, values: new List<CreateValue> { CreateValueModel });

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestGetEntityAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'entity': '_Entity', 'description': 'Description', 'metadata': {}, 'fuzzy_match': true, 'values': [{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}]}";
            var response = new DetailedResponse<Entity>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Entity>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string entity = "testString";
            bool? export = true;
            bool? includeAudit = true;

            request.As<Entity>().Returns(Task.FromResult(response));

            var result = service.GetEntity(workspaceId: workspaceId, entity: entity, export: export, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestUpdateEntityAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'entity': '_Entity', 'description': 'Description', 'metadata': {}, 'fuzzy_match': true, 'values': [{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}]}";
            var response = new DetailedResponse<Entity>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Entity>(responseJson),
                StatusCode = 200
            };

            var CreateValueMetadata = new Dictionary<string, object>();
            var CreateValueSynonyms = new List<string> { "testString" };
            var CreateValuePatterns = new List<string> { "testString" };
            CreateValue CreateValueModel = new CreateValue()
            {
                Value = "testString",
                Metadata = CreateValueMetadata,
                Type = "synonyms",
                Synonyms = CreateValueSynonyms,
                Patterns = CreateValuePatterns,
            };
            string workspaceId = "testString";
            string entity = "testString";

            request.As<Entity>().Returns(Task.FromResult(response));

            var result = service.UpdateEntity(workspaceId: workspaceId, entity: entity, newEntity: "testString", newDescription: "testString", newMetadata: new Dictionary<string, object>(), newFuzzyMatch: true, newValues: new List<CreateValue> { CreateValueModel });

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestDeleteEntityAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.DeleteAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var response = new DetailedResponse<object>()
            {
                Result = new object(),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string entity = "testString";

            request.As<object>().Returns(Task.FromResult(response));

            var result = service.DeleteEntity(workspaceId: workspaceId, entity: entity);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}";
            client.Received().DeleteAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestListMentionsAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'examples': [{'text': 'Text', 'intent': 'Intent', 'location': [8]}], 'pagination': {'refresh_url': 'RefreshUrl', 'next_url': 'NextUrl', 'total': 5, 'matched': 7, 'refresh_cursor': 'RefreshCursor', 'next_cursor': 'NextCursor'}}";
            var response = new DetailedResponse<EntityMentionCollection>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<EntityMentionCollection>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string entity = "testString";
            bool? export = true;
            bool? includeAudit = true;

            request.As<EntityMentionCollection>().Returns(Task.FromResult(response));

            var result = service.ListMentions(workspaceId: workspaceId, entity: entity, export: export, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}/mentions";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestListValuesAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'values': [{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}], 'pagination': {'refresh_url': 'RefreshUrl', 'next_url': 'NextUrl', 'total': 5, 'matched': 7, 'refresh_cursor': 'RefreshCursor', 'next_cursor': 'NextCursor'}}";
            var response = new DetailedResponse<ValueCollection>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<ValueCollection>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string entity = "testString";
            bool? export = true;
            long? pageLimit = 38;
            string sort = "value";
            string cursor = "testString";
            bool? includeAudit = true;

            request.As<ValueCollection>().Returns(Task.FromResult(response));

            var result = service.ListValues(workspaceId: workspaceId, entity: entity, export: export, pageLimit: pageLimit, sort: sort, cursor: cursor, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}/values";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestCreateValueAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}";
            var response = new DetailedResponse<Value>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Value>(responseJson),
                StatusCode = 201
            };

            string workspaceId = "testString";
            string entity = "testString";

            request.As<Value>().Returns(Task.FromResult(response));

            var result = service.CreateValue(workspaceId: workspaceId, entity: entity, value: "testString", metadata: new Dictionary<string, object>(), type: "synonyms", synonyms: new List<string> { "testString" }, patterns: new List<string> { "testString" });

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}/values";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestGetValueAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}";
            var response = new DetailedResponse<Value>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Value>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string entity = "testString";
            string value = "testString";
            bool? export = true;
            bool? includeAudit = true;

            request.As<Value>().Returns(Task.FromResult(response));

            var result = service.GetValue(workspaceId: workspaceId, entity: entity, value: value, export: export, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}/values/{value}";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestUpdateValueAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'value': '_Value', 'metadata': {}, 'type': 'synonyms', 'synonyms': ['Synonym'], 'patterns': ['Pattern']}";
            var response = new DetailedResponse<Value>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Value>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string entity = "testString";
            string value = "testString";

            request.As<Value>().Returns(Task.FromResult(response));

            var result = service.UpdateValue(workspaceId: workspaceId, entity: entity, value: value, newValue: "testString", newMetadata: new Dictionary<string, object>(), newType: "synonyms", newSynonyms: new List<string> { "testString" }, newPatterns: new List<string> { "testString" });

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}/values/{value}";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestDeleteValueAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.DeleteAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var response = new DetailedResponse<object>()
            {
                Result = new object(),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string entity = "testString";
            string value = "testString";

            request.As<object>().Returns(Task.FromResult(response));

            var result = service.DeleteValue(workspaceId: workspaceId, entity: entity, value: value);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}/values/{value}";
            client.Received().DeleteAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestListSynonymsAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'synonyms': [{'synonym': '_Synonym'}], 'pagination': {'refresh_url': 'RefreshUrl', 'next_url': 'NextUrl', 'total': 5, 'matched': 7, 'refresh_cursor': 'RefreshCursor', 'next_cursor': 'NextCursor'}}";
            var response = new DetailedResponse<SynonymCollection>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<SynonymCollection>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string entity = "testString";
            string value = "testString";
            long? pageLimit = 38;
            string sort = "synonym";
            string cursor = "testString";
            bool? includeAudit = true;

            request.As<SynonymCollection>().Returns(Task.FromResult(response));

            var result = service.ListSynonyms(workspaceId: workspaceId, entity: entity, value: value, pageLimit: pageLimit, sort: sort, cursor: cursor, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}/values/{value}/synonyms";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestCreateSynonymAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'synonym': '_Synonym'}";
            var response = new DetailedResponse<Synonym>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Synonym>(responseJson),
                StatusCode = 201
            };

            string workspaceId = "testString";
            string entity = "testString";
            string value = "testString";

            request.As<Synonym>().Returns(Task.FromResult(response));

            var result = service.CreateSynonym(workspaceId: workspaceId, entity: entity, value: value, synonym: "testString");

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}/values/{value}/synonyms";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestGetSynonymAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'synonym': '_Synonym'}";
            var response = new DetailedResponse<Synonym>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Synonym>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string entity = "testString";
            string value = "testString";
            string synonym = "testString";
            bool? includeAudit = true;

            request.As<Synonym>().Returns(Task.FromResult(response));

            var result = service.GetSynonym(workspaceId: workspaceId, entity: entity, value: value, synonym: synonym, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}/values/{value}/synonyms/{synonym}";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestUpdateSynonymAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'synonym': '_Synonym'}";
            var response = new DetailedResponse<Synonym>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<Synonym>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string entity = "testString";
            string value = "testString";
            string synonym = "testString";

            request.As<Synonym>().Returns(Task.FromResult(response));

            var result = service.UpdateSynonym(workspaceId: workspaceId, entity: entity, value: value, synonym: synonym, newSynonym: "testString");

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}/values/{value}/synonyms/{synonym}";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestDeleteSynonymAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.DeleteAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var response = new DetailedResponse<object>()
            {
                Result = new object(),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string entity = "testString";
            string value = "testString";
            string synonym = "testString";

            request.As<object>().Returns(Task.FromResult(response));

            var result = service.DeleteSynonym(workspaceId: workspaceId, entity: entity, value: value, synonym: synonym);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/entities/{entity}/values/{value}/synonyms/{synonym}";
            client.Received().DeleteAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestListDialogNodesAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'dialog_nodes': [{'dialog_node': '_DialogNode', 'description': 'Description', 'conditions': 'Conditions', 'parent': 'Parent', 'previous_sibling': 'PreviousSibling', 'output': {'generic': [{'response_type': 'text', 'values': [{'text': 'Text'}], 'selection_policy': 'sequential', 'delimiter': 'Delimiter', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'query': 'Query', 'query_type': 'natural_language', 'filter': 'Filter', 'discovery_version': 'DiscoveryVersion'}], 'modifiers': {'overwrite': false}}, 'context': {}, 'metadata': {}, 'next_step': {'behavior': 'get_user_input', 'dialog_node': 'DialogNode', 'selector': 'condition'}, 'title': 'Title', 'type': 'standard', 'event_name': 'focus', 'variable': 'Variable', 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}], 'digress_in': 'not_available', 'digress_out': 'allow_returning', 'digress_out_slots': 'not_allowed', 'user_label': 'UserLabel', 'disambiguation_opt_out': true, 'disabled': true}], 'pagination': {'refresh_url': 'RefreshUrl', 'next_url': 'NextUrl', 'total': 5, 'matched': 7, 'refresh_cursor': 'RefreshCursor', 'next_cursor': 'NextCursor'}}";
            var response = new DetailedResponse<DialogNodeCollection>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<DialogNodeCollection>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            long? pageLimit = 38;
            string sort = "dialog_node";
            string cursor = "testString";
            bool? includeAudit = true;

            request.As<DialogNodeCollection>().Returns(Task.FromResult(response));

            var result = service.ListDialogNodes(workspaceId: workspaceId, pageLimit: pageLimit, sort: sort, cursor: cursor, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/dialog_nodes";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestCreateDialogNodeAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'dialog_node': '_DialogNode', 'description': 'Description', 'conditions': 'Conditions', 'parent': 'Parent', 'previous_sibling': 'PreviousSibling', 'output': {'generic': [{'response_type': 'text', 'values': [{'text': 'Text'}], 'selection_policy': 'sequential', 'delimiter': 'Delimiter', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'query': 'Query', 'query_type': 'natural_language', 'filter': 'Filter', 'discovery_version': 'DiscoveryVersion'}], 'modifiers': {'overwrite': false}}, 'context': {}, 'metadata': {}, 'next_step': {'behavior': 'get_user_input', 'dialog_node': 'DialogNode', 'selector': 'condition'}, 'title': 'Title', 'type': 'standard', 'event_name': 'focus', 'variable': 'Variable', 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}], 'digress_in': 'not_available', 'digress_out': 'allow_returning', 'digress_out_slots': 'not_allowed', 'user_label': 'UserLabel', 'disambiguation_opt_out': true, 'disabled': true}";
            var response = new DetailedResponse<DialogNode>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<DialogNode>(responseJson),
                StatusCode = 201
            };

            var DialogNodeActionParameters = new Dictionary<string, object>();
            DialogNodeAction DialogNodeActionModel = new DialogNodeAction()
            {
                Name = "testString",
                Type = "client",
                Parameters = DialogNodeActionParameters,
                ResultVariable = "testString",
                Credentials = "testString"
            };

            DialogNodeNextStep DialogNodeNextStepModel = new DialogNodeNextStep()
            {
                Behavior = "get_user_input",
                DialogNode = "testString",
                Selector = "condition"
            };

            DialogNodeOutputModifiers DialogNodeOutputModifiersModel = new DialogNodeOutputModifiers()
            {
                Overwrite = true
            };

            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            DialogNodeOutputTextValuesElement DialogNodeOutputTextValuesElementModel = new DialogNodeOutputTextValuesElement()
            {
                Text = "testString"
            };

            var DialogNodeOutputGenericValues = new List<DialogNodeOutputTextValuesElement> { DialogNodeOutputTextValuesElementModel };
            var DialogNodeOutputGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogNodeOutputGeneric DialogNodeOutputGenericModel = new DialogNodeOutputGeneric()
            {
                ResponseType = "text",
                Values = DialogNodeOutputGenericValues,
                SelectionPolicy = "sequential",
                Delimiter = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogNodeOutputGenericOptions,
                MessageToHumanAgent = "testString",
                Query = "testString",
                QueryType = "natural_language",
                Filter = "testString",
                DiscoveryVersion = "testString"
            };

            var DialogNodeOutputGeneric = new List<DialogNodeOutputGeneric> { DialogNodeOutputGenericModel };
            DialogNodeOutput DialogNodeOutputModel = new DialogNodeOutput()
            {
                Generic = DialogNodeOutputGeneric,
                Modifiers = DialogNodeOutputModifiersModel
            };
            string workspaceId = "testString";

            request.As<DialogNode>().Returns(Task.FromResult(response));

            var result = service.CreateDialogNode(workspaceId: workspaceId, dialogNode: "testString", description: "testString", conditions: "testString", parent: "testString", previousSibling: "testString", output: DialogNodeOutputModel, context: new Dictionary<string, object>(), metadata: new Dictionary<string, object>(), nextStep: DialogNodeNextStepModel, title: "testString", type: "standard", eventName: "focus", variable: "testString", actions: new List<DialogNodeAction> { DialogNodeActionModel }, digressIn: "not_available", digressOut: "allow_returning", digressOutSlots: "not_allowed", userLabel: "testString", disambiguationOptOut: true);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/dialog_nodes";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestGetDialogNodeAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'dialog_node': '_DialogNode', 'description': 'Description', 'conditions': 'Conditions', 'parent': 'Parent', 'previous_sibling': 'PreviousSibling', 'output': {'generic': [{'response_type': 'text', 'values': [{'text': 'Text'}], 'selection_policy': 'sequential', 'delimiter': 'Delimiter', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'query': 'Query', 'query_type': 'natural_language', 'filter': 'Filter', 'discovery_version': 'DiscoveryVersion'}], 'modifiers': {'overwrite': false}}, 'context': {}, 'metadata': {}, 'next_step': {'behavior': 'get_user_input', 'dialog_node': 'DialogNode', 'selector': 'condition'}, 'title': 'Title', 'type': 'standard', 'event_name': 'focus', 'variable': 'Variable', 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}], 'digress_in': 'not_available', 'digress_out': 'allow_returning', 'digress_out_slots': 'not_allowed', 'user_label': 'UserLabel', 'disambiguation_opt_out': true, 'disabled': true}";
            var response = new DetailedResponse<DialogNode>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<DialogNode>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string dialogNode = "testString";
            bool? includeAudit = true;

            request.As<DialogNode>().Returns(Task.FromResult(response));

            var result = service.GetDialogNode(workspaceId: workspaceId, dialogNode: dialogNode, includeAudit: includeAudit);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/dialog_nodes/{dialogNode}";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestUpdateDialogNodeAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.PostAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'dialog_node': '_DialogNode', 'description': 'Description', 'conditions': 'Conditions', 'parent': 'Parent', 'previous_sibling': 'PreviousSibling', 'output': {'generic': [{'response_type': 'text', 'values': [{'text': 'Text'}], 'selection_policy': 'sequential', 'delimiter': 'Delimiter', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'query': 'Query', 'query_type': 'natural_language', 'filter': 'Filter', 'discovery_version': 'DiscoveryVersion'}], 'modifiers': {'overwrite': false}}, 'context': {}, 'metadata': {}, 'next_step': {'behavior': 'get_user_input', 'dialog_node': 'DialogNode', 'selector': 'condition'}, 'title': 'Title', 'type': 'standard', 'event_name': 'focus', 'variable': 'Variable', 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}], 'digress_in': 'not_available', 'digress_out': 'allow_returning', 'digress_out_slots': 'not_allowed', 'user_label': 'UserLabel', 'disambiguation_opt_out': true, 'disabled': true}";
            var response = new DetailedResponse<DialogNode>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<DialogNode>(responseJson),
                StatusCode = 200
            };

            var DialogNodeActionParameters = new Dictionary<string, object>();
            DialogNodeAction DialogNodeActionModel = new DialogNodeAction()
            {
                Name = "testString",
                Type = "client",
                Parameters = DialogNodeActionParameters,
                ResultVariable = "testString",
                Credentials = "testString"
            };

            DialogNodeNextStep DialogNodeNextStepModel = new DialogNodeNextStep()
            {
                Behavior = "get_user_input",
                DialogNode = "testString",
                Selector = "condition"
            };

            DialogNodeOutputModifiers DialogNodeOutputModifiersModel = new DialogNodeOutputModifiers()
            {
                Overwrite = true
            };

            var CaptureGroupLocation = new List<long?> { 38 };
            CaptureGroup CaptureGroupModel = new CaptureGroup()
            {
                Group = "testString",
                Location = CaptureGroupLocation
            };

            var RuntimeEntityLocation = new List<long?> { 38 };
            var RuntimeEntityMetadata = new Dictionary<string, object>();
            var RuntimeEntityGroups = new List<CaptureGroup> { CaptureGroupModel };
            RuntimeEntity RuntimeEntityModel = new RuntimeEntity()
            {
                Entity = "testString",
                Location = RuntimeEntityLocation,
                Value = "testString",
                Confidence = 72.5f,
                Metadata = RuntimeEntityMetadata,
                Groups = RuntimeEntityGroups
            };

            RuntimeIntent RuntimeIntentModel = new RuntimeIntent()
            {
                Intent = "testString",
                Confidence = 72.5f
            };

            MessageInput MessageInputModel = new MessageInput()
            {
                Text = "testString"
            };

            var DialogNodeOutputOptionsElementValueIntents = new List<RuntimeIntent> { RuntimeIntentModel };
            var DialogNodeOutputOptionsElementValueEntities = new List<RuntimeEntity> { RuntimeEntityModel };
            DialogNodeOutputOptionsElementValue DialogNodeOutputOptionsElementValueModel = new DialogNodeOutputOptionsElementValue()
            {
                Input = MessageInputModel,
                Intents = DialogNodeOutputOptionsElementValueIntents,
                Entities = DialogNodeOutputOptionsElementValueEntities
            };

            DialogNodeOutputOptionsElement DialogNodeOutputOptionsElementModel = new DialogNodeOutputOptionsElement()
            {
                Label = "testString",
                Value = DialogNodeOutputOptionsElementValueModel
            };

            DialogNodeOutputTextValuesElement DialogNodeOutputTextValuesElementModel = new DialogNodeOutputTextValuesElement()
            {
                Text = "testString"
            };

            var DialogNodeOutputGenericValues = new List<DialogNodeOutputTextValuesElement> { DialogNodeOutputTextValuesElementModel };
            var DialogNodeOutputGenericOptions = new List<DialogNodeOutputOptionsElement> { DialogNodeOutputOptionsElementModel };
            DialogNodeOutputGeneric DialogNodeOutputGenericModel = new DialogNodeOutputGeneric()
            {
                ResponseType = "text",
                Values = DialogNodeOutputGenericValues,
                SelectionPolicy = "sequential",
                Delimiter = "testString",
                Time = 38,
                Typing = true,
                Source = "testString",
                Title = "testString",
                Description = "testString",
                Preference = "dropdown",
                Options = DialogNodeOutputGenericOptions,
                MessageToHumanAgent = "testString",
                Query = "testString",
                QueryType = "natural_language",
                Filter = "testString",
                DiscoveryVersion = "testString"
            };

            var DialogNodeOutputGeneric = new List<DialogNodeOutputGeneric> { DialogNodeOutputGenericModel };
            DialogNodeOutput DialogNodeOutputModel = new DialogNodeOutput()
            {
                Generic = DialogNodeOutputGeneric,
                Modifiers = DialogNodeOutputModifiersModel
            };
            string workspaceId = "testString";
            string dialogNode = "testString";

            request.As<DialogNode>().Returns(Task.FromResult(response));

            var result = service.UpdateDialogNode(workspaceId: workspaceId, dialogNode: dialogNode, newDialogNode: "testString", newDescription: "testString", newConditions: "testString", newParent: "testString", newPreviousSibling: "testString", newOutput: DialogNodeOutputModel, newContext: new Dictionary<string, object>(), newMetadata: new Dictionary<string, object>(), newNextStep: DialogNodeNextStepModel, newTitle: "testString", newType: "standard", newEventName: "focus", newVariable: "testString", newActions: new List<DialogNodeAction> { DialogNodeActionModel }, newDigressIn: "not_available", newDigressOut: "allow_returning", newDigressOutSlots: "not_allowed", newUserLabel: "testString", newDisambiguationOptOut: true);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/dialog_nodes/{dialogNode}";
            client.Received().PostAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestDeleteDialogNodeAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.DeleteAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var response = new DetailedResponse<object>()
            {
                Result = new object(),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string dialogNode = "testString";

            request.As<object>().Returns(Task.FromResult(response));

            var result = service.DeleteDialogNode(workspaceId: workspaceId, dialogNode: dialogNode);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/dialog_nodes/{dialogNode}";
            client.Received().DeleteAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestListLogsAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'logs': [{'request': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}], 'alternate_intents': true, 'context': {'conversation_id': 'ConversationId', 'system': {}, 'metadata': {'deployment': 'Deployment', 'user_id': 'UserId'}}, 'output': {'nodes_visited': ['NodesVisited'], 'nodes_visited_details': [{'dialog_node': 'DialogNode', 'title': 'Title', 'conditions': 'Conditions'}], 'log_messages': [{'level': 'info', 'msg': 'Msg'}], 'text': ['Text'], 'generic': [{'response_type': 'text', 'text': 'Text', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'topic': 'Topic', 'dialog_node': 'DialogNode', 'suggestions': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}, 'output': {'nodes_visited': ['NodesVisited'], 'nodes_visited_details': [{'dialog_node': 'DialogNode', 'title': 'Title', 'conditions': 'Conditions'}], 'text': ['Text'], 'generic': [{'response_type': 'text', 'text': 'Text', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'topic': 'Topic', 'dialog_node': 'DialogNode'}]}, 'dialog_node': 'DialogNode'}]}]}, 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}]}, 'response': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}], 'alternate_intents': true, 'context': {'conversation_id': 'ConversationId', 'system': {}, 'metadata': {'deployment': 'Deployment', 'user_id': 'UserId'}}, 'output': {'nodes_visited': ['NodesVisited'], 'nodes_visited_details': [{'dialog_node': 'DialogNode', 'title': 'Title', 'conditions': 'Conditions'}], 'log_messages': [{'level': 'info', 'msg': 'Msg'}], 'text': ['Text'], 'generic': [{'response_type': 'text', 'text': 'Text', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'topic': 'Topic', 'dialog_node': 'DialogNode', 'suggestions': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}, 'output': {'nodes_visited': ['NodesVisited'], 'nodes_visited_details': [{'dialog_node': 'DialogNode', 'title': 'Title', 'conditions': 'Conditions'}], 'text': ['Text'], 'generic': [{'response_type': 'text', 'text': 'Text', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'topic': 'Topic', 'dialog_node': 'DialogNode'}]}, 'dialog_node': 'DialogNode'}]}]}, 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}]}, 'log_id': 'LogId', 'request_timestamp': 'RequestTimestamp', 'response_timestamp': 'ResponseTimestamp', 'workspace_id': 'WorkspaceId', 'language': 'Language'}], 'pagination': {'next_url': 'NextUrl', 'matched': 7, 'next_cursor': 'NextCursor'}}";
            var response = new DetailedResponse<LogCollection>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<LogCollection>(responseJson),
                StatusCode = 200
            };

            string workspaceId = "testString";
            string sort = "testString";
            string filter = "testString";
            long? pageLimit = 38;
            string cursor = "testString";

            request.As<LogCollection>().Returns(Task.FromResult(response));

            var result = service.ListLogs(workspaceId: workspaceId, sort: sort, filter: filter, pageLimit: pageLimit, cursor: cursor);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/workspaces/{workspaceId}/logs";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestListAllLogsAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.GetAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var responseJson = "{'logs': [{'request': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}], 'alternate_intents': true, 'context': {'conversation_id': 'ConversationId', 'system': {}, 'metadata': {'deployment': 'Deployment', 'user_id': 'UserId'}}, 'output': {'nodes_visited': ['NodesVisited'], 'nodes_visited_details': [{'dialog_node': 'DialogNode', 'title': 'Title', 'conditions': 'Conditions'}], 'log_messages': [{'level': 'info', 'msg': 'Msg'}], 'text': ['Text'], 'generic': [{'response_type': 'text', 'text': 'Text', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'topic': 'Topic', 'dialog_node': 'DialogNode', 'suggestions': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}, 'output': {'nodes_visited': ['NodesVisited'], 'nodes_visited_details': [{'dialog_node': 'DialogNode', 'title': 'Title', 'conditions': 'Conditions'}], 'text': ['Text'], 'generic': [{'response_type': 'text', 'text': 'Text', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'topic': 'Topic', 'dialog_node': 'DialogNode'}]}, 'dialog_node': 'DialogNode'}]}]}, 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}]}, 'response': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}], 'alternate_intents': true, 'context': {'conversation_id': 'ConversationId', 'system': {}, 'metadata': {'deployment': 'Deployment', 'user_id': 'UserId'}}, 'output': {'nodes_visited': ['NodesVisited'], 'nodes_visited_details': [{'dialog_node': 'DialogNode', 'title': 'Title', 'conditions': 'Conditions'}], 'log_messages': [{'level': 'info', 'msg': 'Msg'}], 'text': ['Text'], 'generic': [{'response_type': 'text', 'text': 'Text', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'topic': 'Topic', 'dialog_node': 'DialogNode', 'suggestions': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}, 'output': {'nodes_visited': ['NodesVisited'], 'nodes_visited_details': [{'dialog_node': 'DialogNode', 'title': 'Title', 'conditions': 'Conditions'}], 'text': ['Text'], 'generic': [{'response_type': 'text', 'text': 'Text', 'time': 4, 'typing': true, 'source': 'Source', 'title': 'Title', 'description': 'Description', 'preference': 'dropdown', 'options': [{'label': 'Label', 'value': {'input': {'text': 'Text'}, 'intents': [{'intent': 'Intent', 'confidence': 10}], 'entities': [{'entity': 'Entity', 'location': [8], 'value': 'Value', 'confidence': 10, 'metadata': {}, 'groups': [{'group': 'Group', 'location': [8]}]}]}}], 'message_to_human_agent': 'MessageToHumanAgent', 'topic': 'Topic', 'dialog_node': 'DialogNode'}]}, 'dialog_node': 'DialogNode'}]}]}, 'actions': [{'name': 'Name', 'type': 'client', 'parameters': {}, 'result_variable': 'ResultVariable', 'credentials': 'Credentials'}]}, 'log_id': 'LogId', 'request_timestamp': 'RequestTimestamp', 'response_timestamp': 'ResponseTimestamp', 'workspace_id': 'WorkspaceId', 'language': 'Language'}], 'pagination': {'next_url': 'NextUrl', 'matched': 7, 'next_cursor': 'NextCursor'}}";
            var response = new DetailedResponse<LogCollection>()
            {
                Response = responseJson,
                Result = JsonConvert.DeserializeObject<LogCollection>(responseJson),
                StatusCode = 200
            };

            string filter = "testString";
            string sort = "testString";
            long? pageLimit = 38;
            string cursor = "testString";

            request.As<LogCollection>().Returns(Task.FromResult(response));

            var result = service.ListAllLogs(filter: filter, sort: sort, pageLimit: pageLimit, cursor: cursor);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/logs";
            client.Received().GetAsync(messageUrl);
        }

        [TestMethod]
        public void TestTestDeleteUserDataAllParams()
        {
            IClient client = Substitute.For<IClient>();
            IRequest request = Substitute.For<IRequest>();
            client.DeleteAsync(Arg.Any<string>())
                .Returns(request);

            AssistantService service = new AssistantService(client);
            var versionDate = "versionDate";
            service.VersionDate = versionDate;

            var response = new DetailedResponse<object>()
            {
                Result = new object(),
                StatusCode = 202
            };

            string customerId = "testString";

            request.As<object>().Returns(Task.FromResult(response));

            var result = service.DeleteUserData(customerId: customerId);

            request.Received().WithArgument("version", versionDate);

            string messageUrl = $"{service.ServiceUrl}/v1/user_data";
            client.Received().DeleteAsync(messageUrl);
        }

    }
}
