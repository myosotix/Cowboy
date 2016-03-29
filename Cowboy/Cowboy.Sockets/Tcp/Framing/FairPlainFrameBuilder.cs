﻿using System;

namespace Cowboy.Sockets
{
    public sealed class FairPlainFrameBuilder : FrameBuilder
    {
        public FairPlainFrameBuilder()
            : this(new FairPlainFrameEncoder(), new FairPlainFrameDecoder())
        {
        }

        public FairPlainFrameBuilder(FairPlainFrameEncoder encoder, FairPlainFrameDecoder decoder)
            : base(encoder, decoder)
        {
        }
    }

    public sealed class FairPlainFrameEncoder : IFrameEncoder
    {
        public FairPlainFrameEncoder()
        {
        }

        public void EncodeFrame(byte[] payload, int offset, int count, out byte[] frameBuffer, out int frameBufferOffset, out int frameBufferLength)
        {
            frameBuffer = payload;
            frameBufferOffset = offset;
            frameBufferLength = count;
        }
    }

    public sealed class FairPlainFrameDecoder : IFrameDecoder
    {
        public FairPlainFrameDecoder()
        {
        }

        public bool TryDecodeFrame(byte[] buffer, int offset, int count, out int frameLength, out byte[] payload, out int payloadOffset, out int payloadCount)
        {
            frameLength = 0;
            payload = null;
            payloadOffset = 0;
            payloadCount = 0;

            if (count <= 0)
                return false;

            frameLength = count;
            payload = buffer;
            payloadOffset = offset;
            payloadCount = count;
            return true;
        }
    }
}