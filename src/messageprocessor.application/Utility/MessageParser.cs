using MessageProcessor.Application.Exceptions;
using MessageProcessor.Application.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MessageProcessor.Application.Utility
{
    public static class MessageParser
    {
        public static BaseMessageFormat TryParse(JsonElement json)
        {
            var rawJson = json.GetRawText();

            //Validate input is a valid jsonobject
            var jobject = JObject.Parse(rawJson);

            if (!jobject.HasValues)
            {
                throw new MessageParsingException("Input is not a valid message");
            }

            //Get all derived classes from base class
            IEnumerable<Type> derivedTypes = typeof(BaseMessageFormat)
                .Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(BaseMessageFormat)) && !t.IsAbstract);

            var settings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error
            };

            //Try to parse the json in order to find a valid message format
            foreach (var derivedType in derivedTypes)
            {
                try
                {
                    return (BaseMessageFormat)JsonConvert.DeserializeObject(
                        rawJson, derivedType, settings);
                }
                catch
                {
                    //Try the next derived type
                    continue;
                }
            }

            throw new MessageParsingException("Message format was not recognized");
        }
    }
}
