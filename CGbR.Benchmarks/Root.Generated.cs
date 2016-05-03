/*
 * This code was generated by the CGbR generator on 03.05.2016. Any manual changes will be lost on the next build.
 * 
 * For questions or bug reports please refer to https://github.com/Toxantron/CGbR or contact the distributor of the
 * 3rd party generator target.
 */
using CGbR.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CGbR.Benchmarks
{
    /// <summary>
    /// Auto generated class by CGbR project
    /// </summary>
    public partial class Root : IByteSerializable
    {
        #region BinarySerializer

        /// <summary>
        /// Binary size of the object
        /// </summary>
        public int Size
        {
            get 
            { 
                var size = 20;
                // Add size for collections and strings
                size += Description == null ? 0 : Description.Length;
                size += PartialsList == null ? 0 : PartialsList.Sum(entry => entry.Size);
                size += PartialsArray == null ? 0 : PartialsArray.Sum(entry => entry.Size);
  
                return size;              
            }
        }

        /// <summary>
        /// Convert object to bytes
        /// </summary>
        public byte[] ToBytes()
        {
            var index = 0;
            var bytes = new byte[Size];

            return ToBytes(bytes, ref index);
        }

        /// <summary>
        /// Convert object to bytes within object tree
        /// </summary>
        void IByteSerializable.ToBytes(byte[] bytes, ref int index)
        {
            ToBytes(bytes, ref index);
        }

        /// <summary>
        /// Convert object to bytes within object tree
        /// </summary>
        public byte[] ToBytes(byte[] bytes, ref int index)
        {
            if (index + Size > bytes.Length)
                throw new ArgumentOutOfRangeException("index", "Object does not fit in array");

            // Convert Number
            GeneratorByteConverter.Include(Number, bytes, ref index);
            // Convert Price
            GeneratorByteConverter.Include(Price, bytes, ref index);
            // Convert Description
            GeneratorByteConverter.Include(Description, bytes, ref index);
            // Convert PartialsList
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(PartialsList == null ? 0 : PartialsList.Count), bytes, ref index);
            if (PartialsList != null)
            {
                for(var i = 0; i < PartialsList.Count; i++)
                {
                    var value = PartialsList[i];
            		value.ToBytes(bytes, ref index);
                }
            }
            // Convert PartialsArray
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(PartialsArray == null ? 0 : PartialsArray.Length), bytes, ref index);
            if (PartialsArray != null)
            {
                for(var i = 0; i < PartialsArray.Length; i++)
                {
                    var value = PartialsArray[i];
            		value.ToBytes(bytes, ref index);
                }
            }
            // Convert SmallNumber
            GeneratorByteConverter.Include(SmallNumber, bytes, ref index);
            return bytes;
        }

        /// <summary>
        /// Create object from byte array
        /// </summary>
        public Root FromBytes(byte[] bytes)
        {
            var index = 0;            
            return FromBytes(bytes, ref index); 
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        void IByteSerializable.FromBytes(byte[] bytes, ref int index)
        {
            FromBytes(bytes, ref index);
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        public Root FromBytes(byte[] bytes, ref int index)
        {
            // Read Number
            Number = GeneratorByteConverter.ToInt32(bytes, ref index);
            // Read Price
            Price = GeneratorByteConverter.ToDouble(bytes, ref index);
            // Read Description
            Description = GeneratorByteConverter.GetString(bytes, ref index);
            // Read PartialsList
            var partialslistLength = GeneratorByteConverter.ToUInt16(bytes, ref index);
            var tempPartialsList = new List<Partial>(partialslistLength);
            for (var i = 0; i < partialslistLength; i++)
            {
            	var value = new Partial().FromBytes(bytes, ref index);
                tempPartialsList.Add(value);
            }
            PartialsList = tempPartialsList;
            // Read PartialsArray
            var partialsarrayLength = GeneratorByteConverter.ToUInt16(bytes, ref index);
            var tempPartialsArray = new Partial[partialsarrayLength];
            for (var i = 0; i < partialsarrayLength; i++)
            {
            	var value = new Partial().FromBytes(bytes, ref index);
                tempPartialsArray[i] = value;
            }
            PartialsArray = tempPartialsArray;
            // Read SmallNumber
            SmallNumber = GeneratorByteConverter.ToUInt16(bytes, ref index);

            return this;
        }

        
        #endregion

        #region JsonSerializer

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public string ToJson()
        {
            var builder = new StringBuilder();
            using(var writer = new StringWriter(builder))
            {
                IncludeJson(writer);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public void IncludeJson(TextWriter writer)
        {
            writer.Write('{');

            writer.Write("\"Number\":");
            writer.Write(Number.ToString(CultureInfo.InvariantCulture));
    
            writer.Write(",\"Price\":");
            writer.Write(Price.ToString(CultureInfo.InvariantCulture));
    
            writer.Write(",\"Description\":");
            writer.Write(string.Format("\"{0}\"", Description));
    
            writer.Write(",\"PartialsList\":");
            if (PartialsList == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in PartialsList)
                {
            		value.IncludeJson(writer);
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"PartialsArray\":");
            if (PartialsArray == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in PartialsArray)
                {
            		value.IncludeJson(writer);
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"SmallNumber\":");
            writer.Write(SmallNumber.ToString(CultureInfo.InvariantCulture));
    
            writer.Write('}');
        }

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public Root FromJson(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                return FromJson(reader);
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public Root FromJson(JsonReader reader)
        {
            while (reader.Read())
            {
                // Break on EndObject
                if (reader.TokenType == JsonToken.EndObject)
                    break;

                // Only look for properties
                if (reader.TokenType != JsonToken.PropertyName)
                    continue;

                switch ((string) reader.Value)
                {
                    case "Number":
                        reader.Read();
                        Number = Convert.ToInt32(reader.Value);
                        break;

                    case "Price":
                        reader.Read();
                        Price = Convert.ToDouble(reader.Value);
                        break;

                    case "Description":
                        reader.Read();
                        Description = Convert.ToString(reader.Value);
                        break;

                    case "SmallNumber":
                        reader.Read();
                        SmallNumber = Convert.ToUInt16(reader.Value);
                        break;

                    case "PartialsList":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var partialslist = new List<Partial>();
                        while (reader.Read() && reader.TokenType == JsonToken.StartObject)
                            partialslist.Add(new Partial().FromJson(reader));
                        PartialsList = partialslist;
                        break;

                    case "PartialsArray":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var partialsarray = new List<Partial>();
                        while (reader.Read() && reader.TokenType == JsonToken.StartObject)
                            partialsarray.Add(new Partial().FromJson(reader));
                        PartialsArray = partialsarray.ToArray();
                        break;

                }
            }

            return this;
        }

        
        #endregion

    }
}