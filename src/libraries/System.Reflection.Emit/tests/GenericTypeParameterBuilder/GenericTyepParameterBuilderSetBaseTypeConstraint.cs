// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Reflection;
using System.Reflection.Emit;
using Xunit;

namespace System.Reflection.Emit.Tests
{
    public class GenericTypeParameterBuilderSetBaseTypeConstraint
    {
        [Fact]
        public void PosTest1()
        {
            AssemblyName myAsmName = new AssemblyName("GenericEmitExample1");
            AssemblyBuilder myAssembly = AssemblyBuilder.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.Run);
            ModuleBuilder myModule = TestLibrary.Utilities.GetModuleBuilder(myAssembly, myAsmName.Name);

            Type baseType = typeof(ExampleBase);

            TypeBuilder myType = myModule.DefineType("Sample", TypeAttributes.Public);

            string[] typeParamNames = { "TFirst" };
            GenericTypeParameterBuilder[] typeParams = myType.DefineGenericParameters(typeParamNames);

            GenericTypeParameterBuilder TFirst = typeParams[0];

            Type expectedValue = typeof(string);
            Type actualValue;

            TFirst.SetBaseTypeConstraint(typeof(string));
            actualValue = TFirst.BaseType;
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void PosTest2()
        {
            AssemblyName myAsmName = new AssemblyName("GenericEmitExample1");
            AssemblyBuilder myAssembly = AssemblyBuilder.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.Run);
            ModuleBuilder myModule = TestLibrary.Utilities.GetModuleBuilder(myAssembly, myAsmName.Name);

            Type baseType = typeof(ExampleBase);

            TypeBuilder myType = myModule.DefineType("Sample", TypeAttributes.Public);

            string[] typeParamNames = { "TFirst" };
            GenericTypeParameterBuilder[] typeParams = myType.DefineGenericParameters(typeParamNames);

            GenericTypeParameterBuilder TFirst = typeParams[0];

            Type expectedValue = typeof(object);
            Type actualValue;
            TFirst.SetBaseTypeConstraint(null);
            actualValue = TFirst.BaseType;
            Assert.Equal(expectedValue, actualValue);
        }
    }

    public class ExampleBase { }
}
