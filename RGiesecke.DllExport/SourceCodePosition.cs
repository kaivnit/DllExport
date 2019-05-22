﻿//# Author of original code ([Decompiled] MIT-License): Copyright (c) 2009-2015  Robert Giesecke
//# Use Readme & LICENSE files for details.

//# Modifications: Copyright (c) 2016-2019  Denis Kuzmin < entry.reg@gmail.com > GitHub/3F
//$ Distributed under the MIT License (MIT)

using System;

namespace RGiesecke.DllExport
{
    public struct SourceCodePosition: IEquatable<SourceCodePosition>
    {
        private readonly int _Character;
        private readonly int _Line;

        public int Line
        {
            get {
                return this._Line;
            }
        }

        public int Character
        {
            get {
                return this._Character;
            }
        }

        public SourceCodePosition(int line, int character)
        {
            this._Line = line;
            this._Character = character;
        }

        public static bool operator ==(SourceCodePosition left, SourceCodePosition right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SourceCodePosition left, SourceCodePosition right)
        {
            return !left.Equals(right);
        }

        public static SourceCodePosition? FromText(string lineText, string columnText)
        {
            int? nullable1 = new int?();
            int? nullable2 = new int?();
            int result;
            if(int.TryParse(lineText, out result))
            {
                nullable1 = new int?(result);
            }
            if(int.TryParse(columnText, out result))
            {
                nullable2 = new int?(result);
            }
            if(nullable1.HasValue || nullable2.HasValue)
            {
                return new SourceCodePosition?(new SourceCodePosition(nullable1 ?? -1, nullable2 ?? -1));
            }
            return new SourceCodePosition?();
        }

        public bool Equals(SourceCodePosition other)
        {
            if(other._Line == this._Line)
            {
                return other._Character == this._Character;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if(!object.ReferenceEquals((object)null, obj) && obj.GetType() == typeof(SourceCodePosition))
            {
                return this.Equals((SourceCodePosition)obj);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this._Line * 397 ^ this._Character;
        }
    }
}
