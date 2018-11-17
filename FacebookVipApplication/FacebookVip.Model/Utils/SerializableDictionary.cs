using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Xml;
using System.Xml.Serialization;

namespace FacebookVip.Model.Utils
{
    [Serializable]
    public class SerializableDictionary<TKey, TVal> : Dictionary<TKey, TVal>, IXmlSerializable, ISerializable
    {

        #region Constants

        private const string k_DictionaryNodeName = "Dictionary";
        private const string k_ItemNodeName = "Item";
        private const string k_KeyNodeName = "Key";
        private const string k_ValueNodeName = "Value";

        #endregion

        #region Private Members

        private XmlSerializer m_KeySerializer;
        private XmlSerializer m_ValueSerializer;

        #endregion

        #region Private Properties

        private XmlSerializer ValueSerializer
        {
            get
            {
                if (m_ValueSerializer == null)
                {
                    m_ValueSerializer = new XmlSerializer(typeof(TVal));
                }
                return m_ValueSerializer;
            }
        }

        private XmlSerializer KeySerializer
        {
            get
            {
                if (m_KeySerializer == null)
                {
                    m_KeySerializer = new XmlSerializer(typeof(TKey));
                }
                return m_KeySerializer;
            }
        }
        public static string DictionaryNodeName
        {
            get
            {
                return k_DictionaryNodeName;
            }
        }

        #endregion

        #region Constructors

        public SerializableDictionary()
        {
        }

        public SerializableDictionary(IDictionary<TKey, TVal> i_Dictionary)
            : base(i_Dictionary)
        {
        }

        public SerializableDictionary(IEqualityComparer<TKey> i_Comparer)
            : base(i_Comparer)
        {
        }

        public SerializableDictionary(int i_Capacity)
            : base(i_Capacity)
        {
        }

        public SerializableDictionary(IDictionary<TKey, TVal> i_Dictionary, IEqualityComparer<TKey> i_Comparer)
            : base(i_Dictionary, i_Comparer)
        {
        }

        public SerializableDictionary(int i_Capacity, IEqualityComparer<TKey> i_Comparer)
            : base(i_Capacity, i_Comparer)
        {
        }

        #endregion

        #region ISerializable Members

        protected SerializableDictionary(SerializationInfo i_Info, StreamingContext i_Context)
        {
            int itemCount = i_Info.GetInt32("ItemCount");
            for (int i = 0; i < itemCount; i++)
            {
                KeyValuePair<TKey, TVal> kvp = (KeyValuePair<TKey, TVal>)i_Info.GetValue(String.Format("Item{0}", i), typeof(KeyValuePair<TKey, TVal>));
                this.Add(kvp.Key, kvp.Value);
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo i_Info, StreamingContext i_Context)
        {
            i_Info.AddValue("ItemCount", this.Count);
            int itemIdx = 0;
            foreach (KeyValuePair<TKey, TVal> kvp in this)
            {
                i_Info.AddValue(String.Format("Item{0}", itemIdx), kvp, typeof(KeyValuePair<TKey, TVal>));
                itemIdx++;
            }
        }

        #endregion

        #region IXmlSerializable Members

        void IXmlSerializable.WriteXml(XmlWriter i_Writer)
        {
            //writer.WriteStartElement(DictionaryNodeName);
            foreach (KeyValuePair<TKey, TVal> kvp in this)
            {
                i_Writer.WriteStartElement(k_ItemNodeName);
                i_Writer.WriteStartElement(k_KeyNodeName);
                KeySerializer.Serialize(i_Writer, kvp.Key);
                i_Writer.WriteEndElement();
                i_Writer.WriteStartElement(k_ValueNodeName);
                ValueSerializer.Serialize(i_Writer, kvp.Value);
                i_Writer.WriteEndElement();
                i_Writer.WriteEndElement();
            }
        }

        void IXmlSerializable.ReadXml(XmlReader i_Reader)
        {
            if (i_Reader.IsEmptyElement)
            {
                return;
            }

            // Move past container
            if (!i_Reader.Read())
            {
                throw new XmlException("Error in Deserialization of Dictionary");
            }

            while (i_Reader.NodeType != XmlNodeType.EndElement)
            {
                i_Reader.ReadStartElement(k_ItemNodeName);
                i_Reader.ReadStartElement(k_KeyNodeName);
                TKey key = (TKey)KeySerializer.Deserialize(i_Reader);
                i_Reader.ReadEndElement();
                i_Reader.ReadStartElement(k_ValueNodeName);
                TVal value = (TVal)ValueSerializer.Deserialize(i_Reader);
                i_Reader.ReadEndElement();
                i_Reader.ReadEndElement();
                this.Add(key, value);
                i_Reader.MoveToContent();
            }
            //reader.ReadEndElement();

            i_Reader.ReadEndElement(); // Read End Element to close Read of containing node
        }

        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        #endregion

    }
}
