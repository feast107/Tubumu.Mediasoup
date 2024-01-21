// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using System;
using System.Collections.Generic;
using Google.FlatBuffers;
using System.Text.Json.Serialization;

namespace FBS.Consumer
{
    public struct EnableTraceEventRequest : IFlatbufferObject
    {
        private Table __p;
        public ByteBuffer ByteBuffer { get { return __p.bb; } }
        public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_5_26(); }
        public static EnableTraceEventRequest GetRootAsEnableTraceEventRequest(ByteBuffer _bb) { return GetRootAsEnableTraceEventRequest(_bb, new EnableTraceEventRequest()); }
        public static EnableTraceEventRequest GetRootAsEnableTraceEventRequest(ByteBuffer _bb, EnableTraceEventRequest obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
        public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
        public EnableTraceEventRequest __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

        public FBS.Consumer.TraceEventType Events(int j) { int o = __p.__offset(4); return o != 0 ? (FBS.Consumer.TraceEventType)__p.bb.Get(__p.__vector(o) + j * 1) : (FBS.Consumer.TraceEventType)0; }
        public int EventsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<FBS.Consumer.TraceEventType> GetEventsBytes() { return __p.__vector_as_span<FBS.Consumer.TraceEventType>(4, 1); }
#else
        public ArraySegment<byte>? GetEventsBytes() { return __p.__vector_as_arraysegment(4); }
#endif
        public FBS.Consumer.TraceEventType[] GetEventsArray() { int o = __p.__offset(4); if(o == 0) return null; int p = __p.__vector(o); int l = __p.__vector_len(o); FBS.Consumer.TraceEventType[] a = new FBS.Consumer.TraceEventType[l]; for(int i = 0; i < l; i++) { a[i] = (FBS.Consumer.TraceEventType)__p.bb.Get(p + i * 1); } return a; }

        public static Offset<FBS.Consumer.EnableTraceEventRequest> CreateEnableTraceEventRequest(FlatBufferBuilder builder,
            VectorOffset eventsOffset = default(VectorOffset))
        {
            builder.StartTable(1);
            EnableTraceEventRequest.AddEvents(builder, eventsOffset);
            return EnableTraceEventRequest.EndEnableTraceEventRequest(builder);
        }

        public static void StartEnableTraceEventRequest(FlatBufferBuilder builder) { builder.StartTable(1); }
        public static void AddEvents(FlatBufferBuilder builder, VectorOffset eventsOffset) { builder.AddOffset(0, eventsOffset.Value, 0); }
        public static VectorOffset CreateEventsVector(FlatBufferBuilder builder, FBS.Consumer.TraceEventType[] data) { builder.StartVector(1, data.Length, 1); for(int i = data.Length - 1; i >= 0; i--) builder.AddByte((byte)data[i]); return builder.EndVector(); }
        public static VectorOffset CreateEventsVectorBlock(FlatBufferBuilder builder, FBS.Consumer.TraceEventType[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
        public static VectorOffset CreateEventsVectorBlock(FlatBufferBuilder builder, ArraySegment<FBS.Consumer.TraceEventType> data) { builder.StartVector(1, data.Count, 1); builder.Add(data); return builder.EndVector(); }
        public static VectorOffset CreateEventsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<FBS.Consumer.TraceEventType>(dataPtr, sizeInBytes); return builder.EndVector(); }
        public static void StartEventsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
        public static Offset<FBS.Consumer.EnableTraceEventRequest> EndEnableTraceEventRequest(FlatBufferBuilder builder)
        {
            int o = builder.EndTable();
            builder.Required(o, 4);  // events
            return new Offset<FBS.Consumer.EnableTraceEventRequest>(o);
        }
        public EnableTraceEventRequestT UnPack()
        {
            var _o = new EnableTraceEventRequestT();
            this.UnPackTo(_o);
            return _o;
        }
        public void UnPackTo(EnableTraceEventRequestT _o)
        {
            _o.Events = new List<FBS.Consumer.TraceEventType>();
            for(var _j = 0; _j < this.EventsLength; ++_j)
            { _o.Events.Add(this.Events(_j)); }
        }
        public static Offset<FBS.Consumer.EnableTraceEventRequest> Pack(FlatBufferBuilder builder, EnableTraceEventRequestT _o)
        {
            if(_o == null)
                return default(Offset<FBS.Consumer.EnableTraceEventRequest>);
            var _events = default(VectorOffset);
            if(_o.Events != null)
            {
                var __events = _o.Events.ToArray();
                _events = CreateEventsVector(builder, __events);
            }
            return CreateEnableTraceEventRequest(
              builder,
              _events);
        }
    }
}
