// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using System.Text.Json.Serialization;
using Google.FlatBuffers;

namespace FBS.Consumer
{
    public struct SetPreferredLayersResponse : IFlatbufferObject
    {
        private Table __p;
        public ByteBuffer ByteBuffer { get { return __p.bb; } }
        public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_5_26(); }
        public static SetPreferredLayersResponse GetRootAsSetPreferredLayersResponse(ByteBuffer _bb) { return GetRootAsSetPreferredLayersResponse(_bb, new SetPreferredLayersResponse()); }
        public static SetPreferredLayersResponse GetRootAsSetPreferredLayersResponse(ByteBuffer _bb, SetPreferredLayersResponse obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
        public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
        public SetPreferredLayersResponse __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

        public FBS.Consumer.ConsumerLayers? PreferredLayers { get { int o = __p.__offset(4); return o != 0 ? (FBS.Consumer.ConsumerLayers?)(new FBS.Consumer.ConsumerLayers()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }

        public static Offset<FBS.Consumer.SetPreferredLayersResponse> CreateSetPreferredLayersResponse(FlatBufferBuilder builder,
            Offset<FBS.Consumer.ConsumerLayers> preferred_layersOffset = default(Offset<FBS.Consumer.ConsumerLayers>))
        {
            builder.StartTable(1);
            SetPreferredLayersResponse.AddPreferredLayers(builder, preferred_layersOffset);
            return SetPreferredLayersResponse.EndSetPreferredLayersResponse(builder);
        }

        public static void StartSetPreferredLayersResponse(FlatBufferBuilder builder) { builder.StartTable(1); }
        public static void AddPreferredLayers(FlatBufferBuilder builder, Offset<FBS.Consumer.ConsumerLayers> preferredLayersOffset) { builder.AddOffset(0, preferredLayersOffset.Value, 0); }
        public static Offset<FBS.Consumer.SetPreferredLayersResponse> EndSetPreferredLayersResponse(FlatBufferBuilder builder)
        {
            int o = builder.EndTable();
            return new Offset<FBS.Consumer.SetPreferredLayersResponse>(o);
        }
        public SetPreferredLayersResponseT UnPack()
        {
            var _o = new SetPreferredLayersResponseT();
            this.UnPackTo(_o);
            return _o;
        }
        public void UnPackTo(SetPreferredLayersResponseT _o)
        {
            _o.PreferredLayers = this.PreferredLayers.HasValue ? this.PreferredLayers.Value.UnPack() : null;
        }
        public static Offset<FBS.Consumer.SetPreferredLayersResponse> Pack(FlatBufferBuilder builder, SetPreferredLayersResponseT _o)
        {
            if(_o == null)
                return default(Offset<FBS.Consumer.SetPreferredLayersResponse>);
            var _preferred_layers = _o.PreferredLayers == null ? default(Offset<FBS.Consumer.ConsumerLayers>) : FBS.Consumer.ConsumerLayers.Pack(builder, _o.PreferredLayers);
            return CreateSetPreferredLayersResponse(
              builder,
              _preferred_layers);
        }
    }
}
