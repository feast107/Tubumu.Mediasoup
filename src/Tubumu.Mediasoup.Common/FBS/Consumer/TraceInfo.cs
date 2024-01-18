using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FBS.Consumer
{
    public enum TraceInfo : byte
    {
        NONE = 0,

        KeyFrameTraceInfo = 1,

        FirTraceInfo = 2,

        PliTraceInfo = 3,

        RtpTraceInfo = 4,
    }

    public class TraceInfoUnion
    {
        public TraceInfo Type { get; set; }
        public object Value { get; set; }

        public T As<T>() where T : class { return (this.Value as T)!; }
        public FBS.Consumer.KeyFrameTraceInfoT AsKeyFrameTraceInfo() { return this.As<FBS.Consumer.KeyFrameTraceInfoT>(); }
        public static TraceInfoUnion FromKeyFrameTraceInfo(FBS.Consumer.KeyFrameTraceInfoT _keyframetraceinfo) { return new TraceInfoUnion { Type = TraceInfo.KeyFrameTraceInfo, Value = _keyframetraceinfo }; }
        public FBS.Consumer.FirTraceInfoT AsFirTraceInfo() { return this.As<FBS.Consumer.FirTraceInfoT>(); }
        public static TraceInfoUnion FromFirTraceInfo(FBS.Consumer.FirTraceInfoT _firtraceinfo) { return new TraceInfoUnion { Type = TraceInfo.FirTraceInfo, Value = _firtraceinfo }; }
        public FBS.Consumer.PliTraceInfoT AsPliTraceInfo() { return this.As<FBS.Consumer.PliTraceInfoT>(); }
        public static TraceInfoUnion FromPliTraceInfo(FBS.Consumer.PliTraceInfoT _plitraceinfo) { return new TraceInfoUnion { Type = TraceInfo.PliTraceInfo, Value = _plitraceinfo }; }
        public FBS.Consumer.RtpTraceInfoT AsRtpTraceInfo() { return this.As<FBS.Consumer.RtpTraceInfoT>(); }
        public static TraceInfoUnion FromRtpTraceInfo(FBS.Consumer.RtpTraceInfoT _rtptraceinfo) { return new TraceInfoUnion { Type = TraceInfo.RtpTraceInfo, Value = _rtptraceinfo }; }

        public static int Pack(Google.FlatBuffers.FlatBufferBuilder builder, TraceInfoUnion _o)
        {
            switch(_o.Type)
            {
                default:
                    return 0;
                case TraceInfo.KeyFrameTraceInfo:
                    return FBS.Consumer.KeyFrameTraceInfo.Pack(builder, _o.AsKeyFrameTraceInfo()).Value;
                case TraceInfo.FirTraceInfo:
                    return FBS.Consumer.FirTraceInfo.Pack(builder, _o.AsFirTraceInfo()).Value;
                case TraceInfo.PliTraceInfo:
                    return FBS.Consumer.PliTraceInfo.Pack(builder, _o.AsPliTraceInfo()).Value;
                case TraceInfo.RtpTraceInfo:
                    return FBS.Consumer.RtpTraceInfo.Pack(builder, _o.AsRtpTraceInfo()).Value;
            }
        }
    }
}
