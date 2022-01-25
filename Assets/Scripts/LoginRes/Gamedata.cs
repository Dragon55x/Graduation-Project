// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: gamedata.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace XProgect {

  /// <summary>Holder for reflection information generated from gamedata.proto</summary>
  public static partial class GamedataReflection {

    #region Descriptor
    /// <summary>File descriptor for gamedata.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GamedataReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5nYW1lZGF0YS5wcm90bxIJWF9Qcm9nZWN0ImIKCEdhbWVkYXRhEgoKAklE",
            "GAEgASgJEhAKCFBhc3N3b3JkGAIgASgJEgwKBG5hbWUYAyABKAkSDAoEY29p",
            "bhgEIAEoBRINCgVsZXZlbBgFIAEoBRINCgV0b3dlchgGIAMoCWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::XProgect.Gamedata), global::XProgect.Gamedata.Parser, new[]{ "ID", "Password", "Name", "Coin", "Level", "Tower" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Gamedata : pb::IMessage<Gamedata>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Gamedata> _parser = new pb::MessageParser<Gamedata>(() => new Gamedata());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Gamedata> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::XProgect.GamedataReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Gamedata() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Gamedata(Gamedata other) : this() {
      iD_ = other.iD_;
      password_ = other.password_;
      name_ = other.name_;
      coin_ = other.coin_;
      level_ = other.level_;
      tower_ = other.tower_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Gamedata Clone() {
      return new Gamedata(this);
    }

    /// <summary>Field number for the "ID" field.</summary>
    public const int IDFieldNumber = 1;
    private string iD_ = "";
    /// <summary>
    ///后面的 = 1是参数标签，必须有
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ID {
      get { return iD_; }
      set {
        iD_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Password" field.</summary>
    public const int PasswordFieldNumber = 2;
    private string password_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Password {
      get { return password_; }
      set {
        password_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 3;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "coin" field.</summary>
    public const int CoinFieldNumber = 4;
    private int coin_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Coin {
      get { return coin_; }
      set {
        coin_ = value;
      }
    }

    /// <summary>Field number for the "level" field.</summary>
    public const int LevelFieldNumber = 5;
    private int level_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Level {
      get { return level_; }
      set {
        level_ = value;
      }
    }

    /// <summary>Field number for the "tower" field.</summary>
    public const int TowerFieldNumber = 6;
    private static readonly pb::FieldCodec<string> _repeated_tower_codec
        = pb::FieldCodec.ForString(50);
    private readonly pbc::RepeatedField<string> tower_ = new pbc::RepeatedField<string>();
    /// <summary>
    ///repeated可以理解为List，等价于List&lt;int> pos;
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<string> Tower {
      get { return tower_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Gamedata);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Gamedata other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ID != other.ID) return false;
      if (Password != other.Password) return false;
      if (Name != other.Name) return false;
      if (Coin != other.Coin) return false;
      if (Level != other.Level) return false;
      if(!tower_.Equals(other.tower_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ID.Length != 0) hash ^= ID.GetHashCode();
      if (Password.Length != 0) hash ^= Password.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Coin != 0) hash ^= Coin.GetHashCode();
      if (Level != 0) hash ^= Level.GetHashCode();
      hash ^= tower_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (ID.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ID);
      }
      if (Password.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Password);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Name);
      }
      if (Coin != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Coin);
      }
      if (Level != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Level);
      }
      tower_.WriteTo(output, _repeated_tower_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (ID.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ID);
      }
      if (Password.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Password);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Name);
      }
      if (Coin != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Coin);
      }
      if (Level != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Level);
      }
      tower_.WriteTo(ref output, _repeated_tower_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (ID.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ID);
      }
      if (Password.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Password);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Coin != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Coin);
      }
      if (Level != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Level);
      }
      size += tower_.CalculateSize(_repeated_tower_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Gamedata other) {
      if (other == null) {
        return;
      }
      if (other.ID.Length != 0) {
        ID = other.ID;
      }
      if (other.Password.Length != 0) {
        Password = other.Password;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Coin != 0) {
        Coin = other.Coin;
      }
      if (other.Level != 0) {
        Level = other.Level;
      }
      tower_.Add(other.tower_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            ID = input.ReadString();
            break;
          }
          case 18: {
            Password = input.ReadString();
            break;
          }
          case 26: {
            Name = input.ReadString();
            break;
          }
          case 32: {
            Coin = input.ReadInt32();
            break;
          }
          case 40: {
            Level = input.ReadInt32();
            break;
          }
          case 50: {
            tower_.AddEntriesFrom(input, _repeated_tower_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            ID = input.ReadString();
            break;
          }
          case 18: {
            Password = input.ReadString();
            break;
          }
          case 26: {
            Name = input.ReadString();
            break;
          }
          case 32: {
            Coin = input.ReadInt32();
            break;
          }
          case 40: {
            Level = input.ReadInt32();
            break;
          }
          case 50: {
            tower_.AddEntriesFrom(ref input, _repeated_tower_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code