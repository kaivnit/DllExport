﻿/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2016-2019  Denis Kuzmin < entry.reg@gmail.com > GitHub/3F
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/

using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using net.r_eg.DllExport.Wizard.UI.Extensions;

namespace net.r_eg.DllExport.Wizard.UI.Controls
{
    public partial class ProgressLineControl: UserControl
    {
        private volatile bool stop;

        public void StartTrainEffect(int lenLimit, int step = 40, int delay = 50)
        {
            if(!stop) {
                return;
            }
            stop = false;

            void animate()
            {
                if(Width >= lenLimit) {
                    Left += step;

                    if(Left >= lenLimit) {
                        ResetTrainEffect();
                    }
                }
                else {
                    Width += step;
                }
            };

            Task.Factory.StartNew(() => 
            {
                while(true)
                {
                    this.UIAction(animate);

                    if(stop) {
                        this.UIAction(ResetTrainEffect);
                        return;
                    }

                    Thread.Sleep(delay);
                }
            });
        }

        public void StopAll()
        {
            stop = true;
        }

        public ProgressLineControl()
        {
            InitializeComponent();
            StopAll();
        }

        protected void ResetTrainEffect()
        {
            Width = 0;
            Left = 0;
        }

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            StopAll();

            if(disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
