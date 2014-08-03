﻿// OsmSharp - OpenStreetMap (OSM) SDK
// Copyright (C) 2013 Abelshausen Ben
// 
// This file is part of OsmSharp.
// 
// OsmSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// OsmSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.

using OsmSharp.Collections.Arrays;
using OsmSharp.IO.MemoryMappedFiles;
using OsmSharp.Math.Geo.Simple;
using System;

namespace OsmSharp.Routing.Graph
{
    /// <summary>
    /// An implementation of an in-memory dynamic graph using memory mapped files to handle huge graphs.
    /// </summary>
    /// <typeparam name="TEdgeData"></typeparam>
    public class MemoryMappedFileDynamicGraph<TEdgeData> : MemoryDynamicGraph<TEdgeData>, IDisposable
        where TEdgeData : struct, IDynamicGraphEdgeData
    {
        /// <summary>
        /// Holds the coordinates array.
        /// </summary>
        private MemoryMappedHugeArray<GeoCoordinateSimple> _coordinates;

        /// <summary>
        /// Holds the vertex array.
        /// </summary>
        private MemoryMappedHugeArray<uint> _vertices;

        /// <summary>
        /// Holds the edges array.
        /// </summary>
        private MemoryMappedHugeArray<uint> _edges;

        /// <summary>
        /// Creates a new memory mapped file dynamic graph.
        /// </summary>
        /// <param name="estimatedSize"></param>
        public MemoryMappedFileDynamicGraph(long estimatedSize)
            : this(estimatedSize,
            new MemoryMappedHugeArray<GeoCoordinateSimple>(estimatedSize),
            new MemoryMappedHugeArray<uint>(estimatedSize),
            new MemoryMappedHugeArray<uint>(estimatedSize),
            new HugeArray<TEdgeData>(estimatedSize))
        {

        }

        /// <summary>
        /// Creates a new memory mapped file dynamic graph.
        /// </summary>
        /// <param name="estimatedSize"></param>
        /// <param name="arraySize"></param>
        public MemoryMappedFileDynamicGraph(long estimatedSize, int arraySize)
            : this(estimatedSize,
            new MemoryMappedHugeArray<GeoCoordinateSimple>(estimatedSize, arraySize),
            new MemoryMappedHugeArray<uint>(estimatedSize, arraySize),
            new MemoryMappedHugeArray<uint>(estimatedSize, arraySize),
            new HugeArray<TEdgeData>(estimatedSize, arraySize))
        {

        }

        /// <summary>
        /// Creates a new memory mapped file dynamic graph.
        /// </summary>
        /// <param name="estimatedSize"></param>
        /// <param name="path"></param>
        public MemoryMappedFileDynamicGraph(long estimatedSize, string path)
            : this(estimatedSize,
            new MemoryMappedHugeArray<GeoCoordinateSimple>(path, estimatedSize),
            new MemoryMappedHugeArray<uint>(path, estimatedSize),
            new MemoryMappedHugeArray<uint>(path, estimatedSize),
            new HugeArray<TEdgeData>(estimatedSize))
        {

        }

        /// <summary>
        /// Creates a new memory mapped file dynamic graph.
        /// </summary>
        /// <param name="estimatedSize"></param>
        /// <param name="path"></param>
        /// <param name="arraySize"></param>
        public MemoryMappedFileDynamicGraph(long estimatedSize, int arraySize, string path)
            : this(estimatedSize,
            new MemoryMappedHugeArray<GeoCoordinateSimple>(path, estimatedSize, arraySize),
            new MemoryMappedHugeArray<uint>(path, estimatedSize, arraySize),
            new MemoryMappedHugeArray<uint>(path, estimatedSize, arraySize),
            new HugeArray<TEdgeData>(estimatedSize, arraySize))
        {

        }

        /// <summary>
        /// Creates a new memory mapped file dynamic graph.
        /// </summary>
        /// <param name="estimatedSize"></param>
        /// <param name="coordinates"></param>
        /// <param name="vertices"></param>
        /// <param name="edges"></param>
        /// <param name="edgeData"></param>
        public MemoryMappedFileDynamicGraph(long estimatedSize,
            MemoryMappedHugeArray<GeoCoordinateSimple> coordinates,
            MemoryMappedHugeArray<uint> vertices,
            MemoryMappedHugeArray<uint> edges,
            IHugeArray<TEdgeData> edgeData)
            : base(estimatedSize, coordinates, vertices, edges, edgeData)
        {
            _coordinates = coordinates;
            _vertices = vertices;
            _edges = edges;
        }

        /// <summary>
        /// Disposes of all native resources associated with this memory dynamic graph.
        /// </summary>
        public void Dispose()
        {
            _coordinates.Dispose();
            _coordinates = null;
            _edges.Dispose();
            _edges = null;
            _vertices.Dispose();
            _vertices = null;
        }
    }
}