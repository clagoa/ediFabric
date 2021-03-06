﻿//---------------------------------------------------------------------
// This file is part of ediFabric
//
// Copyright (c) ediFabric. All rights reserved.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
// PURPOSE.
//---------------------------------------------------------------------

using EdiFabric.Framework.Constants;

namespace EdiFabric.Framework
{
    /// <summary>
    /// EDI separators.
    /// </summary>
    public sealed class Separators
    {
        /// <summary>
        /// Separator for segments.
        /// </summary>
        public char Segment { get; private set; }

        /// <summary>
        /// Separator for component data elements.
        /// </summary>
        public char ComponentDataElement { get; private set; }

        /// <summary>
        /// Release indicator for escaping terminators.
        /// </summary>
        public char? Escape { get; private set; }

        ///<summary>
        /// Separator for data elements.
        /// </summary>
        public char DataElement { get; private set; }

        /// <summary>
        /// Separator for repetitions of data elements.
        /// </summary>
        public char RepetitionDataElement { get; private set; }

        internal Separators(char segment, char componentDataElement, char dataElement,
            char repetitionDataElement, char? escape)
        {
            ComponentDataElement = componentDataElement;
            DataElement = dataElement;
            Escape = escape;
            RepetitionDataElement = repetitionDataElement;
            Segment = segment;
        }

        /// <summary>
        /// Factory method to initialize a new instance of the <see cref="Separators"/> class.
        /// </summary>
        /// <param name="segment">Separator for segments.</param>
        /// <param name="componentDataElement">Separator for component data elements.</param>
        /// <param name="dataElement">Separator for data elements.</param>
        /// <param name="repetitionDataElement">Separator for repetitions of data elements.</param>
        /// <returns>A new instance of the <see cref="Separators"/> class.</returns>
        public static Separators SeparatorsX12(char segment, char componentDataElement, char dataElement,
            char repetitionDataElement)
        {
            return new Separators(segment, componentDataElement, dataElement, repetitionDataElement, null);
        }

        /// <summary>
        /// Factory method to initialize a new instance of the <see cref="Separators"/> class.
        /// </summary>
        /// <param name="segment">Separator for segments.</param>
        /// <param name="componentDataElement">Separator for component data elements.</param>
        /// <param name="dataElement">Separator for data elements.</param>
        /// <param name="repetitionDataElement">Separator for repetitions of data elements.</param>
        /// <param name="escape">Release indicator for escaping terminators.</param>
        /// <returns>A new instance of the <see cref="Separators"/> class.</returns>
        public static Separators SeparatorsEdifact(char segment, char componentDataElement, char dataElement,
            char repetitionDataElement, char? escape)
        {
            return new Separators(segment, componentDataElement, dataElement, repetitionDataElement, escape);
        }

        /// <summary>
        /// Factory method to initialize a new instance of the <see cref="Separators"/> class.
        /// Uses the default X12 separators.
        /// </summary>
        /// <returns>A new instance of the <see cref="Separators"/> class with all default separators.</returns>
        public static Separators DefaultSeparatorsX12()
        {
            return new Separators('~', '>', '*', '^', null);
        }

        /// <summary>
        /// Factory method to initialize a new instance of the <see cref="Separators"/> class.
        /// Uses the default EDIFACT separators.
        /// </summary>
        /// <returns>A new instance of the <see cref="Separators"/> class with all default separators.</returns>
        public static Separators DefaultSeparatorsEdifact()
        {
            return new Separators('\'', ':', '+', '*', '?');
        }

        /// <summary>
        /// Creates UNA segment.
        /// </summary>
        /// <returns>The separators.</returns>
        internal string ToUna()
        {
            return SegmentTags.UNA.ToString() + ComponentDataElement + DataElement + "." + Escape + " " + Segment;
        }
    }
}
