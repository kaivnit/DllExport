﻿//# Author of original code ([Decompiled] MIT-License): Copyright (c) 2009-2015  Robert Giesecke
//# Use Readme & LICENSE files for details.

//# Modifications: Copyright (c) 2016-2019  Denis Kuzmin < entry.reg@gmail.com > GitHub/3F
//$ Distributed under the MIT License (MIT)

namespace RGiesecke.DllExport.Parsing.Actions
{
    public interface IParserStateAction
    {
        long Milliseconds
        {
            get;
            set;
        }

        IlParser Parser
        {
            get;
            set;
        }

        void Execute(ParserStateValues state, string trimmedLine);
    }
}
