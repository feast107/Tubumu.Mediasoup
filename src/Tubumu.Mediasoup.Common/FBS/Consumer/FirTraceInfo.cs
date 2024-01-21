// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using Google.FlatBuffers;
using System.Text.Json.Serialization;

namespace FBS.Consumer
{
    public struct FirTraceInfo : IFlatbufferObject
    {
        private Table __p;
        public ByteBuffer ByteBuffer { get { return __p.bb; } }
        public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_5_26(); }
        public static FirTraceInfo GetRootAsFirTraceInfo(ByteBuffer _bb) { return GetRootAsFirTraceInfo(_bb, new FirTraceInfo()); }
        public static FirTraceInfo GetRootAsFirTraceInfo(ByteBuffer _bb, FirTraceInfo obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
        public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
        public FirTraceInfo __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

        public uint Ssrc { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }

        public static Offset<FBS.Consumer.FirTraceInfo> CreateFirTraceInfo(FlatBufferBuilder builder,
            uint ssrc = 0)
        {
            builder.StartTable(1);
            FirTraceInfo.AddSsrc(builder, ssrc);
            return FirTraceInfo.EndFirTraceInfo(builder);
        }

        public static void StartFirTraceInfo(FlatBufferBuilder builder) { builder.StartTable(1); }
        public static void AddSsrc(FlatBufferBuilder builder, uint ssrc) { builder.AddUint(0, ssrc, 0); }
        public static Offset<FBS.Consumer.FirTraceInfo> EndFirTraceInfo(FlatBufferBuilder builder)
        {
            int o = builder.EndTable();
            return new Offset<FBS.Consumer.FirTraceInfo>(o);
        }
        public FirTraceInfoT UnPack()
        {
            var _o = new FirTraceInfoT();
            this.UnPackTo(_o);
            return _o;
        }
        public void UnPackTo(FirTraceInfoT _o)
        {
            _o.Ssrc = this.Ssrc;
        }
        public static Offset<FBS.Consumer.FirTraceInfo> Pack(FlatBufferBuilder builder, FirTraceInfoT _o)
        {
            if(_o == null)
                return default(Offset<FBS.Consumer.FirTraceInfo>);
            return CreateFirTraceInfo(
              builder,
              _o.Ssrc);
        }
    }
}
