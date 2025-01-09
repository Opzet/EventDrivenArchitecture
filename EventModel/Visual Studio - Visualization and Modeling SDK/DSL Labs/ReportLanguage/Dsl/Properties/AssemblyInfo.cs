#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle(@"")]
[assembly: AssemblyDescription(@"")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(@"Company")]
[assembly: AssemblyProduct(@"ReportLanguage")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.Resources.NeutralResourcesLanguage("en")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion(@"1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]

//
// Make the Dsl project internally visible to the DslPackage assembly
//
[assembly: InternalsVisibleTo(@"Company.ReportLanguage.DslPackage, PublicKey=0024000004800000940000000602000000240000525341310004000001000100A9EDAEF0258D830DD42B32E979DCE65FBB1074D5E2F2F32F5BACBB01343F376BD17EE481D240917DF13B112E5A64B4326AB181D4C9C174D815D5F45ACD9583DE9332E3E6498116399D54A6547910343A868540EC2F00A1709CA62D721B145281355CA7D8D8157DB5CA437076A08C62446B9A982E498F03E351B95DECFAB0EE90")]