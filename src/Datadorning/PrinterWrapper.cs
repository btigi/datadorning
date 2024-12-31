using ESC_POS_USB_NET.Printer;
using PluginBase;
using ESC_POS_USB_NET.Enums;

namespace Datadorning
{
    public class PrinterWrapper : IDatadorningPrinter
    {
        private readonly Printer printer;
        public PrinterWrapper(Printer printer)
        {
            this.printer = printer;
        }

        public int ColsNomal => printer.ColsNomal;

        public int ColsCondensed => printer.ColsCondensed;

        public int ColsExpanded => printer.ColsExpanded;

        public void AlignCenter()
        {
            printer.AlignCenter();
        }

        public void AlignLeft()
        {
            printer.AlignLeft();
        }

        public void AlignRight()
        {
            printer.AlignRight();
        }

        public void Append(string value)
        {
            printer.Append(value);
        }

        public void Append(byte[] value)
        {
            printer.Append(value);
        }

        public void AppendWithoutLf(string value)
        {
            printer.AppendWithoutLf(value);
        }

        public void AutoTest()
        {
            printer.AutoTest();
        }

        public void BoldMode(string value)
        {
            printer.BoldMode(value);
        }

        public void BoldMode(PrinterModeState state)
        {
            printer.BoldMode(state);
        }

        public void Clear()
        {
            printer.Clear();
        }

        public void CondensedMode(string value)
        {
            printer.CondensedMode(value);
        }

        public void CondensedMode(PrinterModeState state)
        {
            printer.CondensedMode(state);
        }

        public void DoubleWidth2()
        {
            printer.DoubleWidth2();
        }

        public void DoubleWidth3()
        {
            printer.DoubleWidth3();
        }

        public void ExpandedMode(string value)
        {
            printer.ExpandedMode(value);
        }

        public void ExpandedMode(PrinterModeState state)
        {
            printer.ExpandedMode(state);
        }

        public void FullPaperCut()
        {
            printer.FullPaperCut();
        }
        public void InitializePrint()
        {
            throw new NotImplementedException();
        }

        public void NewLine()
        {
            printer.NewLine();
        }

        public void NewLines(int lines)
        {
            printer.NewLines(lines);
        }

        public void NormalLineHeight()
        {
            printer.NormalLineHeight();
        }

        public void NormalWidth()
        {
            printer.NormalWidth();
        }

        public void OpenDrawer()
        {
            printer.OpenDrawer();
        }

        public void PartialPaperCut()
        {
            printer.PartialPaperCut();
        }

        public void PrintDocument()
        {
            printer.PrintDocument();
        }

        public void QrCode(string qrData)
        {
            printer.QrCode(qrData);
        }

        public void Separator(char speratorChar = '-')
        {
            printer.Separator(speratorChar);
        }

        public void SetLineHeight(byte height)
        {
            printer.SetLineHeight(height);
        }

        public void TestPrinter()
        {
            printer.TestPrinter();
        }

        public void UnderlineMode(string value)
        {
            printer.UnderlineMode(value);
        }

        public void UnderlineMode(PrinterModeState state)
        {
            printer.UnderlineMode(state);
        }
    }
}