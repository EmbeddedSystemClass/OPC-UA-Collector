/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ServerCollector
{
    /// <summary>
    /// Defines constants for namespaces used by the application.
    /// </summary>
    public static partial class Namespaces
    {
        
	/// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";
   
        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for Simatic Node Extension namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        // public const string OpcUaXsdSimatic = "http://www.siemens.com/OPCUA/2017/SimaticNodeSetExtensions";

        /// <summary>
        /// The URI for the Boiler namespace (.NET code namespace is 'Quickstarts.Boiler').
        /// </summary>
        // public const string Boiler = "http://opcfoundation.org/Quickstarts/Boiler";
        // URI für Namespace Demo
        public const string Demo = "http://demo.demo/Demo";

        //UD -- wichtig, ansonsten werden die Informationen nicht gefunden
        public const string OpcUaDI = "http://opcfoundation.org/UA/DI/";

        // URI für Namespace DFT.MachineLocationV2
        public const string DFT = "http://DFT_MaschineV2.org";

        //Collector Namespace
        public const string Collector = "http://htw-berlin.de/opcua/Collector";
        // URI für Namespace MES 
        public const string MESEuromap83 = "http://www.euromap.org/euromap83/";
        public const string MESEuromap77 = "http://www.euromap.org/euromap77/";     
        public const string MESSiemensDemo = "http://www.OEM.com/siemens/euromap77Demo";

        // URI für Namespace zum Testen einfacher Methoden
        public const string Methods = "http://opcfoundation.org/Quickstarts/Methods";
    }
}
