﻿namespace LightInject.Tests
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

#if NET || NET45 || NET45TEST || NET46
    using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#endif
#if NETFX_CORE || WINDOWS_PHONE || IOS
    using LocalBuilder = LightInject.LocalBuilder;
    using ILGenerator = LightInject.ILGenerator;
#endif

    [TestClass]
    public class EmitterTests
    {
#if IOS
        [TestMethod]
        public void Emit_SByte_ReturnsInteger()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldc_I4_S, (sbyte)42);
            var result = (int)generator.ExecuteUsingOneArgument(new object[] { });
            Assert.AreEqual(42, result);

        }

        [TestMethod]
        public void Emit_Byte_ReturnsByte()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldc_I4_S, (byte)42);
            var result = (int)generator.ExecuteUsingOneArgument(new object[] { });
            Assert.AreEqual(42, result);

        }

        [TestMethod]
        public void Emit_Ldarg_ReturnsArgument()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldarg, 0);
            var result = (int)generator.ExecuteUsingOneArgument(42);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Emit_Ldloc_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.DeclareLocal(typeof(int));
            generator.Emit(OpCodes.Ldarg, 0);
            generator.Emit(OpCodes.Stloc, 0);
            generator.Emit(OpCodes.Ldloc, 0);
            var result = (int)generator.ExecuteUsingOneArgument(42);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Emit_Ldloc_0_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.DeclareLocal(typeof(int));
            generator.Emit(OpCodes.Ldarg, 0);
            generator.Emit(OpCodes.Stloc_0);
            generator.Emit(OpCodes.Ldloc_0);
            var result = (int)generator.ExecuteUsingOneArgument(42);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Emit_Ldloc_1_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.DeclareLocal(typeof(int));
            generator.DeclareLocal(typeof(int));
            generator.Emit(OpCodes.Ldarg, 0);
            generator.Emit(OpCodes.Stloc_1);
            generator.Emit(OpCodes.Ldloc_1);
            var result = (int)generator.ExecuteUsingOneArgument(42);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Emit_Ldloc_2_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.DeclareLocal(typeof(int));
            generator.DeclareLocal(typeof(int));
            generator.DeclareLocal(typeof(int));
            generator.Emit(OpCodes.Ldarg, 0);
            generator.Emit(OpCodes.Stloc_2);
            generator.Emit(OpCodes.Ldloc_2);
            var result = (int)generator.ExecuteUsingOneArgument(42);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Emit_Ldloc_3_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.DeclareLocal(typeof(int));
            generator.DeclareLocal(typeof(int));
            generator.DeclareLocal(typeof(int));
            generator.DeclareLocal(typeof(int));
            generator.Emit(OpCodes.Ldarg, 0);
            generator.Emit(OpCodes.Stloc_3);
            generator.Emit(OpCodes.Ldloc_3);
            var result = (int)generator.ExecuteUsingOneArgument(42);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Emit_MethodInfoWithInvalidOpCode_ThrowsException()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldarg, (MethodInfo)null);
            generator.ExecuteUsingOneArgument(new object[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Emit_TypeWithInvalidOpCode_ThrowsException()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldarg, (Type)null);
            generator.ExecuteUsingOneArgument(new object[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Emit_LocalBuilderWithInvalidOpCode_ThrowsException()
        {
            var generator = new ILGenerator();
            var local = generator.DeclareLocal(typeof(int));
            generator.Emit(OpCodes.Ldarg, local);
            generator.ExecuteUsingOneArgument(new object[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Emit_IntWithInvalidOpCode_ThrowsException()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldarg_0, 42);
            generator.ExecuteUsingOneArgument(new object[] { });
        }

        [TestMethod]
        public void Emit_Ldc_I4_0_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldc_I4_0);
            var result = (int)generator.ExecuteUsingOneArgument(new object[] { });
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Emit_Ldc_I4_1_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldc_I4_1);
            var result = (int)generator.ExecuteUsingOneArgument(new object[] { });
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Emit_Ldc_I4_2_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldc_I4_2);
            var result = (int)generator.ExecuteUsingOneArgument(new object[] { });
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Emit_Ldc_I4_3_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldc_I4_3);
            var result = (int)generator.ExecuteUsingOneArgument(new object[] { });
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Emit_Ldc_I4_4_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldc_I4_4);
            var result = (int)generator.ExecuteUsingOneArgument(new object[] { });
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Emit_Ldc_I4_5_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldc_I4_5);
            var result = (int)generator.ExecuteUsingOneArgument(new object[] { });
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Emit_Ldc_I4_6_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldc_I4_6);
            var result = (int)generator.ExecuteUsingOneArgument(new object[] { });
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Emit_Ldc_I4_7_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldc_I4_7);
            var result = (int)generator.ExecuteUsingOneArgument(new object[] { });
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Emit_Ldc_I4_8_ReturnsValue()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Ldc_I4_8);
            var result = (int)generator.ExecuteUsingOneArgument(new object[] { });
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Emit_Nop_ThrowsException()
        {
            var generator = new ILGenerator();
            generator.Emit(OpCodes.Nop);
            generator.ExecuteUsingOneArgument(new object[] { });
        }
#endif

        [TestMethod]
        public void Push_Zero_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            emitter.Push(0);
            emitter.Return();
            Assert.AreEqual(OpCodes.Ldc_I4_0, emitter.Instructions[0].Code);            
        }

        [TestMethod]
        public void Push_One_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(1);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4_1, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_Two_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(2);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4_2, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_Three_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(3);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4_3, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_Four_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(4);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4_4, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_Five_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(5);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4_5, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_Six_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(6);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4_6, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_Seven_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(7);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4_7, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_Eigth_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(8);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4_8, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_Nine_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(9);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4_S, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_SignedByteMaxValue_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(sbyte.MaxValue);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4_S, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_SignedByteMinValue_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(sbyte.MinValue);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4_S, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_SignedByteMaxValuePlusOne_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(sbyte.MaxValue + 1);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Push_SignedByteMinValueMinusOne_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();

            emitter.Push(sbyte.MinValue - 1);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldc_I4, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushArgument_Zero_EmitsMostEffectiveInstruction()
        {
            const int ArgumentNumber = 0;
            var emitter = CreateEmitter(ArgumentNumber);

            emitter.PushArgument(ArgumentNumber);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldarg_0, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushArgument_One_EmitsMostEffectiveInstruction()
        {
            const int ArgumentCount = 1;
            var emitter = CreateEmitter(ArgumentCount);

            emitter.PushArgument(ArgumentCount);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldarg_1, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushArgument_Two_EmitsMostEffectiveInstruction()
        {
            const int ArgumentCount = 2;
            var emitter = CreateEmitter(ArgumentCount);

            emitter.PushArgument(ArgumentCount);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldarg_2, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushArgument_Three_EmitsMostEffectiveInstruction()
        {
            const int ArgumentCount = 3;
            var emitter = CreateEmitter(ArgumentCount);

            emitter.PushArgument(ArgumentCount);
            emitter.Return();
            
            Assert.AreEqual(OpCodes.Ldarg_3, emitter.Instructions[0].Code);
        }

        private Emitter CreateEmitter(int ArgumentNumber)
        {
            Type[] arguments = CreateArgumentArray(ArgumentNumber);
            var emitter = new Emitter(CreateDummyGenerator(arguments), arguments);
            return emitter;
        }

        private Emitter CreateEmitter()
        {
            Type[] arguments = CreateArgumentArray(0);
            var emitter = new Emitter(CreateDummyGenerator(arguments), arguments);
            return emitter;
        }

        [TestMethod]
        public void PushArgument_Four_EmitsMostEffectiveInstruction()
        {
            const int ArgumentCount = 4;
            var emitter = CreateEmitter(ArgumentCount);

            emitter.PushArgument(ArgumentCount);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldarg_S, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushArgument_ByteMaxValue_EmitsMostEffectiveInstruction()
        {
            const int ArgumentCount = byte.MaxValue;
            var emitter = CreateEmitter(ArgumentCount);

            emitter.PushArgument(ArgumentCount);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldarg_S, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushArgument_ByteMaxValuePlusOne_EmitsMostEffectiveInstruction()
        {
            const int ArgumentCount = byte.MaxValue + 1;
            var emitter = CreateEmitter(ArgumentCount);

            emitter.PushArgument(ArgumentCount);
            emitter.Return();
            
            Assert.AreEqual(OpCodes.Ldarg, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushVariable_One_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, 1);

            emitter.Push(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldloc_0, emitter.Instructions[0].Code);            
        }

        [TestMethod]
        public void PushVariable_Two_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, 2);

            emitter.Push(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldloc_1, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushVariable_Three_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, 3);

            emitter.Push(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldloc_2, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushVariable_Four_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, 4);

            emitter.Push(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldloc_3, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushVariable_Five_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, 5);

            emitter.Push(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldloc_S, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushVariable_ByteMaxValuePlusOne_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, byte.MaxValue + 1);

            emitter.Push(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldloc_S, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void PushVariable_ByteMaxValuePlusTwo_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, byte.MaxValue + 2);
            
            emitter.Push(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Ldloc, emitter.Instructions[0].Code);
        }

        [TestMethod]
        public void Store_One_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, 1);
            
            emitter.Push(42);
            emitter.Store(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Stloc_0, emitter.Instructions[1].Code);
        }

        [TestMethod]
        public void Store_Two_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, 2);

            emitter.Push(42);
            emitter.Store(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Stloc_1, emitter.Instructions[1].Code);
        }

        [TestMethod]
        public void Store_Three_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, 3);

            emitter.Push(42);
            emitter.Store(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Stloc_2, emitter.Instructions[1].Code);
        }

        [TestMethod]
        public void Store_Four_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, 4);

            emitter.Push(42);
            emitter.Store(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Stloc_3, emitter.Instructions[1].Code);
        }

        [TestMethod]
        public void Store_Five_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, 5);

            emitter.Push(42);
            emitter.Store(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Stloc_S, emitter.Instructions[1].Code);
        }

        [TestMethod]
        public void Store_ByteMaxValuePlusOne_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, byte.MaxValue + 1);

            emitter.Push(42);
            emitter.Store(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Stloc_S, emitter.Instructions[1].Code);
        }

        [TestMethod]
        public void Store_ByteMaxValuePlusTwo_EmitsMostEffectiveInstruction()
        {
            var emitter = CreateEmitter();
            var localBuilders = CreateLocalBuilders(emitter, byte.MaxValue + 2);

            emitter.Push(42);
            emitter.Store(localBuilders[localBuilders.Length - 1]);
            emitter.Return();

            Assert.AreEqual(OpCodes.Stloc, emitter.Instructions[1].Code);
        }


        [TestMethod]        
        public void Emit_InvalidOpCodeWithInteger_ThrowsNotSupportedException()
        {
            var emitter = new Emitter(null, new Type[] {});
            ExceptionAssert.Throws<NotSupportedException>(() => emitter.Emit(OpCodes.Ldarg_0, 42));

        }
        
        [TestMethod]        
        public void Emit_InvalidOpCodeWithLocalBuilder_ThrowsNotSupportedException()
        {
            var emitter = new Emitter(null, new Type[] {});
            ExceptionAssert.Throws<NotSupportedException>(() => emitter.Emit(OpCodes.Ldarg_0, (LocalBuilder)null));
        }

        [TestMethod]        
        public void Emit_InvalidOpCodeWithSignedByte_ThrowsNotSupportedException()
        {
            var emitter = new Emitter(null, new Type[] {});
            ExceptionAssert.Throws<NotSupportedException>(() => emitter.Emit(OpCodes.Ldarg_0, (sbyte)42));            
        }

        [TestMethod]        
        public void Emit_InvalidOpCodeWithByte_ThrowsNotSupportedException()
        {
            var emitter = new Emitter(null, new Type[] {});
            ExceptionAssert.Throws<NotSupportedException>(() => emitter.Emit(OpCodes.Ldarg_0, (byte)42));                        
        }

        [TestMethod]        
        public void Emit_InvalidOpCodeWithType_ThrowsNotSupportedException()
        {
            var emitter = new Emitter(null, new Type[] {});
            ExceptionAssert.Throws<NotSupportedException>(() => emitter.Emit(OpCodes.Ldarg_0, typeof(object)));                                    
        }

        [TestMethod]        
        public void Emit_InvalidOpCodeWithMethodInfo_ThrowsNotSupportedException()
        {
            var emitter = new Emitter(null, new Type[] {});
            ExceptionAssert.Throws<NotSupportedException>(() =>  emitter.Emit(OpCodes.Ldarg_0, (MethodInfo)null));
        }

        [TestMethod]        
        public void Emit_InvalidOpCodeWithConstructorInfo_ThrowsNotSupportedException()
        {
            var emitter = new Emitter(null, new Type[] {});
            ExceptionAssert.Throws<NotSupportedException>(() => emitter.Emit(OpCodes.Ldarg_0, (ConstructorInfo)null));            
        }

        [TestMethod]        
        public void Emit_InvalidOpCode_ThrowsNotSupportedException()
        {
            var emitter = new Emitter(null, new Type[] {});
            ExceptionAssert.Throws<NotSupportedException>(() => emitter.Emit(OpCodes.Xor));                        
        }

        [TestMethod]
        public void Push_Zero_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});
            
            emitter.Push(0);

            Assert.AreEqual(typeof(int), emitter.StackType);
        }

        [TestMethod]
        public void Push_One_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(1);

            Assert.AreEqual(typeof(int), emitter.StackType);
        }

        [TestMethod]
        public void Push_Two_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(2);

            Assert.AreEqual(typeof(int), emitter.StackType);
        }

        [TestMethod]
        public void Push_Three_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(3);

            Assert.AreEqual(typeof(int), emitter.StackType);
        }

        [TestMethod]
        public void Push_Four_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(4);

            Assert.AreEqual(typeof(int), emitter.StackType);
        }

        [TestMethod]
        public void Push_Five_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(5);

            Assert.AreEqual(typeof(int), emitter.StackType);
        }

        [TestMethod]
        public void Push_Six_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(6);

            Assert.AreEqual(typeof(int), emitter.StackType);
        }

        [TestMethod]
        public void Push_Seven_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(7);

            Assert.AreEqual(typeof(int), emitter.StackType);
        }

        [TestMethod]
        public void Push_Eight_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(8);

            Assert.AreEqual(typeof(int), emitter.StackType);
        }

        [TestMethod]
        public void Push_Nine_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(9);

            Assert.AreEqual(typeof(sbyte), emitter.StackType);
        }

        [TestMethod]
        public void Push_SignedByteMaxValue_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(sbyte.MaxValue);

            Assert.AreEqual(typeof(sbyte), emitter.StackType);
        }

        [TestMethod]
        public void Push_SignedByteMaxValuePlusOne_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(sbyte.MaxValue + 1);

            Assert.AreEqual(typeof(int), emitter.StackType);
        }

        [TestMethod]
        public void Push_SignedByteMinValue_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(sbyte.MinValue);

            Assert.AreEqual(typeof(sbyte), emitter.StackType);
        }

        [TestMethod]
        public void Push_SignedByteMinValueMinusOne_ReturnsCorrectStackType()
        {
            var emitter = new Emitter(null, new Type[] {});

            emitter.Push(sbyte.MinValue - 1);

            Assert.AreEqual(typeof(int), emitter.StackType);
        }

        [TestMethod]
        public void StackType_EmptyMethod_IsNull()
        {
            var emitter = new Emitter(null, new Type[] {});
            
            Assert.IsNull(emitter.StackType);
        }

        [TestMethod]
        public void ToString_Instruction_ReturnsCodeAsString()
        {
            var instruction = new Instruction(OpCodes.Stloc, null);
            
            Assert.AreEqual("stloc", instruction.ToString());
        }

        [TestMethod]
        public void ToString_InstructionOfT_ReturnsCodeAndArgumentAsString()
        {
            var instruction = new Instruction<int>(OpCodes.Ldarg, 1, null);

            Assert.AreEqual("ldarg 1", instruction.ToString());
        }
      
#if NET || NET45 || NET46
        private ILGenerator CreateDummyGenerator(Type[] parameterTypes)
        {
            return new DynamicMethod(string.Empty, typeof(object), new Type[]{typeof(object[])}).GetILGenerator();
        }
#endif
#if NETFX_CORE || WINDOWS_PHONE
        private ILGenerator CreateDummyGenerator(Type[] parameterTypes)
        {
            return new LightInject.DynamicMethod(typeof(object), parameterTypes).GetILGenerator();
        }        
#endif
#if IOS
        private ILGenerator CreateDummyGenerator(Type[] parameterTypes)
        {
            return new LightInject.DynamicMethod(parameterTypes).GetILGenerator();
        }        
#endif


        private LocalBuilder[] CreateLocalBuilders(IEmitter emitter, int count)
        {
            var localBuilders = new LocalBuilder[count];
            
            for (int i = 0; i < count; i++)
            {
                localBuilders[i] = emitter.DeclareLocal(typeof(sbyte));
            }

            return localBuilders;
        }


        private Type[] CreateArgumentArray(int parameterCount)
        {
            Type[] parameterTypes = new Type[parameterCount + 1];
            for (int i = 0; i < parameterCount + 1; i++)
            {
                parameterTypes[i] = typeof(object);
            }
            return parameterTypes;
        }
    }    
}