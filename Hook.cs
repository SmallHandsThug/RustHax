using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using ProtoBuf;

class DumbHook
{

    private byte[] original;

    public MethodInfo OriginalMethod { get; private set; }
    public MethodInfo HookMethod { get; private set; }

    public MethodInfo OriginalNew { get; private set; }



    public DumbHook()
    {
        original = null;
        OriginalMethod = HookMethod = null;
    }

    public DumbHook(MethodInfo orig, MethodInfo hook, MethodInfo orignew)
    {
        original = null;
        Init(orig, hook, orignew);
    }

    public DumbHook(Type typeOrig, string nameOrig, Type typeHook, string nameHook, Type typeOrigNew, string nameOrigNew, byte[] orig)
    {

        original = new byte[orig.Length];
        original = orig;


        if (nameOrig == "DoHit")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(HitTest), typeof(Vector3), typeof(Vector3) }, null), typeHook.GetMethod(nameHook, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(HitTest), typeof(Vector3), typeof(Vector3) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(HitTest), typeof(Vector3), typeof(Vector3) }, null));
        }

        if (nameOrig == "GetMinSpeed")
        {
            Init(typeOrig.GetMethod(nameOrig), typeHook.GetMethod(nameHook), typeOrigNew.GetMethod(nameOrigNew));
        }

        if (nameOrig == "GetSpeed")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(float), typeof(float) }, null), typeHook.GetMethod(nameHook, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(float), typeof(float) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(float), typeof(float) }, null));
        }

        if (nameOrig == "CanAttack")
        {
            Init(typeOrig.GetMethod(nameOrig), typeHook.GetMethod(nameHook), typeOrigNew.GetMethod(nameOrigNew));
        }

        if (nameOrig == "SendProjectileAttack")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(PlayerProjectileAttack) }, null), typeHook.GetMethod(nameHook, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(PlayerProjectileAttack) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(PlayerProjectileAttack) }, null));
        }

        if (nameOrig == "OnAttacked")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(HitInfo) }, null), typeHook.GetMethod(nameHook, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(HitInfo) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(HitInfo) }, null));
        }

        if (nameOrig == "CreateOrUpdateEntity")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(ProtoBuf.Entity), typeof(long) }, null), typeHook.GetMethod(nameHook, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(ProtoBuf.Entity), typeof(long) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(ProtoBuf.Entity), typeof(long) }, null));
        }

        if (nameOrig == "UpdatePositionFromNetwork")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(Vector3) }, null), typeHook.GetMethod(nameHook, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(Vector3) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(Vector3) }, null));
        }

        if (nameOrig == "IsDead")
        {
            Init(typeOrig.GetMethod(nameOrig), typeHook.GetMethod(nameHook), typeOrigNew.GetMethod(nameOrigNew));
        }

        if (nameOrig == "CreateProjectile" && Type.Equals(typeOrig, typeof(BaseProjectile)))
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(Vector3), typeof(Vector3), typeof(Vector3) }, null), typeHook.GetMethod(nameHook, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(Vector3), typeof(Vector3), typeof(Vector3) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(Vector3), typeof(Vector3), typeof(Vector3) }, null));
        }

        if (nameOrig == "CreateProjectile" && Type.Equals(typeOrig, typeof(BaseMelee)))
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(Vector3), typeof(Vector3), typeof(Vector3) }, null), typeHook.GetMethod(nameHook, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(Vector3), typeof(Vector3), typeof(Vector3) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(Vector3), typeof(Vector3), typeof(Vector3) }, null));
        }

        if (nameOrig == "OnDeploy")
        {
            Init(typeOrig.GetMethod(nameOrig), typeHook.GetMethod(nameHook), typeOrigNew.GetMethod(nameOrigNew));
        }

        if (nameOrig == "get_isAlive")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] {  }, null), typeHook.GetMethod(nameHook, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] {  }, null));
        }

        if (nameOrig == "UpdateServer")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Facepunch.Steamworks.ServerList.Server) }, null), typeHook.GetMethod(nameHook, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Facepunch.Steamworks.ServerList.Server) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Facepunch.Steamworks.ServerList.Server) }, null));
        }

        if (nameOrig == "CanJump")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {}, null), typeHook.GetMethod(nameHook, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null));
        }

        if (nameOrig == "StartAttackCooldown")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(float) }, null), typeHook.GetMethod(nameHook, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(float) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(float) }, null));
        }

        if (nameOrig == "Update" && nameHook == "EnvSyncUpdate")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null), typeHook.GetMethod(nameHook, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null));
        }

        if (nameOrig == "ServerRPC")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(string), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) }, null), typeHook.GetMethod(nameHook, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(string), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(string), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) }, null));
        }

        if (nameOrig == "OnTextureWasEdited")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Texture2D) }, null), typeHook.GetMethod(nameHook, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Texture2D) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Texture2D) }, null));
        }

        if (nameOrig == "DrawTexture")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Vector2), typeof(float), typeof(float), typeof(Texture2D), typeof(Color) }, null), typeHook.GetMethod(nameHook, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Vector2), typeof(float), typeof(float), typeof(Texture2D), typeof(Color) }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Vector2), typeof(float), typeof(float), typeof(Texture2D), typeof(Color) }, null));
        }

        if (nameOrig == "CanTalk")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null), typeHook.GetMethod(nameHook, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null));
        }

        if (nameOrig == "ShouldReceiveVoice")
        {
            Init(typeOrig.GetMethod(nameOrig, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null), typeHook.GetMethod(nameHook, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null), typeOrigNew.GetMethod(nameOrigNew, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null));
        }

    }


    public void Init(MethodInfo orig, MethodInfo hook, MethodInfo orignew)
    {
        if (MethodInfo.Equals(orig, null))
            throw new ArgumentException("Original method is null");

        if (MethodInfo.Equals(hook, null))
            throw new ArgumentException("Hook method is null");

        RuntimeHelpers.PrepareMethod(orig.MethodHandle);
        RuntimeHelpers.PrepareMethod(hook.MethodHandle);
        RuntimeHelpers.PrepareMethod(orignew.MethodHandle);

        OriginalMethod = orig;
        HookMethod = hook;
        OriginalNew = orignew;
    }

    unsafe public void Hook()
    {
        if (MethodInfo.Equals(OriginalMethod, null) || MethodInfo.Equals(HookMethod, null))
            throw new ArgumentException("Hook has to be properly Init'd before use");

        IntPtr functionOriginal = OriginalMethod.MethodHandle.GetFunctionPointer();
        IntPtr functionHook = HookMethod.MethodHandle.GetFunctionPointer();
        IntPtr functionTrampoline = OriginalNew.MethodHandle.GetFunctionPointer();

        uint oldProt;

        Import.VirtualProtect(functionTrampoline, (uint)original.Length + 12, 0x40, out oldProt);
        {
            byte* ptr = (byte*)functionTrampoline;

            for (int i = 0; i < original.Length; ++i)
            {
                ptr[i] = original[i];
            }

            *(ptr + original.Length) = 0x48;
            *(ptr + original.Length + 1) = 0xb8;
            *(IntPtr*)(ptr + original.Length + 2) = (IntPtr)(functionOriginal.ToInt64() + original.Length);
            *(ptr + original.Length + 10) = 0xff;
            *(ptr + original.Length + 11) = 0xe0;
        }
        Import.VirtualProtect(functionTrampoline, (uint)original.Length + 12, oldProt, out oldProt);

        Import.VirtualProtect(functionOriginal, 12, 0x40, out oldProt);
        {
            byte* ptr = (byte*)functionOriginal;

            // movabs rax, addy
            // jmp rax
            *(ptr) = 0x48;
            *(ptr + 1) = 0xb8;
            *(IntPtr*)(ptr + 2) = functionHook;
            *(ptr + 10) = 0xff;
            *(ptr + 11) = 0xe0;
        }
        Import.VirtualProtect(functionOriginal, 12, oldProt, out oldProt);

    }

    unsafe public void Unhook()
    {

        IntPtr functionOriginal = OriginalMethod.MethodHandle.GetFunctionPointer();
        IntPtr functionHook = HookMethod.MethodHandle.GetFunctionPointer();
        IntPtr functionTrampoline = OriginalNew.MethodHandle.GetFunctionPointer();

        uint oldProt;

        Import.VirtualProtect(functionOriginal, 12, 0x40, out oldProt);
        {
            byte* ptr = (byte*)functionOriginal;
            for(int x = 0; x < original.Length; x++)
            {
                *(ptr + x) = original[x];
            }
        }
        Import.VirtualProtect(functionOriginal, 12, oldProt, out oldProt);

    }

    internal class Import
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool VirtualProtect(IntPtr address, uint size, uint newProtect, out uint oldProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr VirtualAlloc(UInt32 lpAddress, UInt32 dwSize, AllocationType lAllocationType, MemoryProtection flProtect);

        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }
        [Flags()]

        public enum MemoryProtection : uint
        {
            EXECUTE = 0x10,
            EXECUTE_READ = 0x20,
            EXECUTE_READWRITE = 0x40,
            EXECUTE_WRITECOPY = 0x80,
            NOACCESS = 0x01,
            READONLY = 0x02,
            READWRITE = 0x04,
            WRITECOPY = 0x08,
            GUARD_Modifierflag = 0x100,
            NOCACHE_Modifierflag = 0x200,
            WRITECOMBINE_Modifierflag = 0x400
        }
    }
}