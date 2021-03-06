/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

/*
 *
 *  Marshaler code for OpenWire format for DestinationInfo
 *
 *  NOTE!: This file is auto generated - do not modify!
 *         if you need to make a change, please see the Java Classes
 *         in the nms-activemq-openwire-generator module
 *
 */

using System;
using System.IO;

using Apache.NMS.ActiveMQ.Commands;

namespace Apache.NMS.ActiveMQ.OpenWire.V7
{
    /// <summary>
    ///  Marshalling code for Open Wire Format for DestinationInfo
    /// </summary>
    class DestinationInfoMarshaller : BaseCommandMarshaller
    {
        /// <summery>
        ///  Creates an instance of the Object that this marshaller handles.
        /// </summery>
        public override DataStructure CreateObject() 
        {
            return new DestinationInfo();
        }

        /// <summery>
        ///  Returns the type code for the Object that this Marshaller handles..
        /// </summery>
        public override byte GetDataStructureType() 
        {
            return DestinationInfo.ID_DESTINATIONINFO;
        }

        // 
        // Un-marshal an object instance from the data input stream
        // 
        public override void TightUnmarshal(OpenWireFormat wireFormat, Object o, BinaryReader dataIn, BooleanStream bs) 
        {
            base.TightUnmarshal(wireFormat, o, dataIn, bs);

            DestinationInfo info = (DestinationInfo)o;
            info.ConnectionId = (ConnectionId) TightUnmarshalCachedObject(wireFormat, dataIn, bs);
            info.Destination = (ActiveMQDestination) TightUnmarshalCachedObject(wireFormat, dataIn, bs);
            info.OperationType = dataIn.ReadByte();
            info.Timeout = TightUnmarshalLong(wireFormat, dataIn, bs);

            if (bs.ReadBoolean()) {
                short size = dataIn.ReadInt16();
                BrokerId[] value = new BrokerId[size];
                for( int i=0; i < size; i++ ) {
                    value[i] = (BrokerId) TightUnmarshalNestedObject(wireFormat,dataIn, bs);
                }
                info.BrokerPath = value;
            }
            else {
                info.BrokerPath = null;
            }
        }

        //
        // Write the booleans that this object uses to a BooleanStream
        //
        public override int TightMarshal1(OpenWireFormat wireFormat, Object o, BooleanStream bs)
        {
            DestinationInfo info = (DestinationInfo)o;

            int rc = base.TightMarshal1(wireFormat, o, bs);
            rc += TightMarshalCachedObject1(wireFormat, (DataStructure)info.ConnectionId, bs);
            rc += TightMarshalCachedObject1(wireFormat, (DataStructure)info.Destination, bs);
            rc += TightMarshalLong1(wireFormat, info.Timeout, bs);
            rc += TightMarshalObjectArray1(wireFormat, info.BrokerPath, bs);

            return rc + 1;
        }

        // 
        // Write a object instance to data output stream
        //
        public override void TightMarshal2(OpenWireFormat wireFormat, Object o, BinaryWriter dataOut, BooleanStream bs)
        {
            base.TightMarshal2(wireFormat, o, dataOut, bs);

            DestinationInfo info = (DestinationInfo)o;
            TightMarshalCachedObject2(wireFormat, (DataStructure)info.ConnectionId, dataOut, bs);
            TightMarshalCachedObject2(wireFormat, (DataStructure)info.Destination, dataOut, bs);
            dataOut.Write(info.OperationType);
            TightMarshalLong2(wireFormat, info.Timeout, dataOut, bs);
            TightMarshalObjectArray2(wireFormat, info.BrokerPath, dataOut, bs);
        }

        // 
        // Un-marshal an object instance from the data input stream
        // 
        public override void LooseUnmarshal(OpenWireFormat wireFormat, Object o, BinaryReader dataIn) 
        {
            base.LooseUnmarshal(wireFormat, o, dataIn);

            DestinationInfo info = (DestinationInfo)o;
            info.ConnectionId = (ConnectionId) LooseUnmarshalCachedObject(wireFormat, dataIn);
            info.Destination = (ActiveMQDestination) LooseUnmarshalCachedObject(wireFormat, dataIn);
            info.OperationType = dataIn.ReadByte();
            info.Timeout = LooseUnmarshalLong(wireFormat, dataIn);

            if (dataIn.ReadBoolean()) {
                short size = dataIn.ReadInt16();
                BrokerId[] value = new BrokerId[size];
                for( int i=0; i < size; i++ ) {
                    value[i] = (BrokerId) LooseUnmarshalNestedObject(wireFormat,dataIn);
                }
                info.BrokerPath = value;
            }
            else {
                info.BrokerPath = null;
            }
        }

        // 
        // Write a object instance to data output stream
        //
        public override void LooseMarshal(OpenWireFormat wireFormat, Object o, BinaryWriter dataOut)
        {

            DestinationInfo info = (DestinationInfo)o;

            base.LooseMarshal(wireFormat, o, dataOut);
            LooseMarshalCachedObject(wireFormat, (DataStructure)info.ConnectionId, dataOut);
            LooseMarshalCachedObject(wireFormat, (DataStructure)info.Destination, dataOut);
            dataOut.Write(info.OperationType);
            LooseMarshalLong(wireFormat, info.Timeout, dataOut);
            LooseMarshalObjectArray(wireFormat, info.BrokerPath, dataOut);
        }
    }
}
