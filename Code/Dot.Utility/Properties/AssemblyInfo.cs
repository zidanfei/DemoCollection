﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("Dot.Utility")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Dot.Utility")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("f3432138-43be-4270-a75e-60a31fec65f5")]

// 程序集的版本信息由下面四个值组成: 
//
//      主版本
//      次版本 
//      生成号
//      修订号
//
// 可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”: 
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.3.42.0")]
[assembly: AssemblyFileVersion("1.3.42.0")]

//http://my.oschina.net/knife2013/blog/127849
[assembly: InternalsVisibleTo("Dot, PublicKey=0024000004800000940000000602000000240000525341310004000001000100eb40f254fbef0f556dae1ecf119a87aa71fa4b2389ddfe5d86a15acfaa95ee67efae1d4d0622a05c3afebf8dc3831caae7ce8482846bd4fc86d53b8a19ae4ce3a665f75b225d6b5e16202b991263cee23bb484bba55f5397a522ec793d214e05f946b3d8f29d1d353ee8b794240ee43853566a425fdec9549d9c5fa59a6d32a4")]


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "./Config/log4net.xml", ConfigFileExtension = "xml", Watch = true)]


