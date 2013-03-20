﻿// OsmSharp - OpenStreetMap tools & library.
// Copyright (C) 2012 Abelshausen Ben
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsmSharp.Routing.Core.Graph.DynamicGraph
{
    /// <summary>
    /// Abstracts an graph implementation. 
    /// </summary>
    public interface IDynamicGraphReadOnly<EdgeData>
        where EdgeData : IDynamicGraphEdgeData
    {
        /// <summary>
        /// Gets an existing vertex.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        bool GetVertex(uint id, out float latitude, out float longitude);

        /// <summary>
        /// Returns an enumerable of all vertices.
        /// </summary>
        /// <returns></returns>
        IEnumerable<uint> GetVertices();

        /// <summary>
        /// Returns all arcs for the given vertex.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        KeyValuePair<uint, EdgeData>[] GetArcs(uint vertex);

        /// <summary>
        /// Returns true if the given vertex has the neighbour as a neighbour.
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="neighbour"></param>
        /// <returns></returns>
        bool HasNeighbour(uint vertex, uint neighbour);

        /// <summary>
        /// Returns the total number of vertices.
        /// </summary>
        uint VertexCount
        {
            get;
        }
    }
}