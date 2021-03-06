﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.Upload
{
    public class FileChunkMetaData
    {
        public string ChunkIdentifier { get; set; }

        public long? ChunkStart { get; set; }

        public long? ChunkEnd { get; set; }

        public long? TotalLength { get; set; }

        public bool IsLastChunk
        {
            get { return ChunkEnd + 1 >= TotalLength; }
        }
    }
}
