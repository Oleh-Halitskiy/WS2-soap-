using CoreWCF;
using SOAPSender.Mocks;
using System;
using System.Runtime.Serialization;
using XMLTools;

namespace SOAPSender
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetData(int value);
        [OperationContract]
        string GetBaseByID(int id);

        [OperationContract]
        string TestIDbase(int id);

        [OperationContract]
        string GetBaseByCPTName(string name);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }

    public class Service : IService
    {
        public string GetData(int value)
        {
            Console.WriteLine("Received value");
            return string.Format("You entered: {0}", value);
        }

        public string GetBaseByID(int id)
        {
            var mb = DatabaseMock.GetBaseByID(id);
            XMLSerializer serializer = new XMLSerializer();
            serializer.SerializeObject(mb, @"C:\jsonTest\WS2\mb.xml");
            return Utils.FileManager.SelectFile(@"C:\jsonTest\WS2\mb.xml");
        }

        public string GetBaseByCPTName(string name)
        {
            var mb = DatabaseMock.GetBaseByCPTName(name);
            XMLSerializer serializer = new XMLSerializer();
            serializer.SerializeObject(mb, @"C:\jsonTest\WS2\mb.xml");
            return Utils.FileManager.SelectFile(@"C:\jsonTest\WS2\mb.xml");
        }

        public string TestIDbase(int id)
        {
            return id.ToString();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
