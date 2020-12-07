using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace CDARender
{
  class Program
  {
    static void Main(string[] args)
    {
      string CDA = @"CDA\CDA_ROOT.XML";
      //string CDA = @"CDA\DavidCAI_CDA.xml";
      //string CDA = @"CDA\CDA_ROOT_8859-1.XML";
      //string CDA = @"CDA\20180906DischargeSummaryJohnGot.xml";
      //string CDA = @"CDA\20180906EventSummaryJohnGot.xml";

      //string Xslt_Stylesheet = @"Xslt\DH_Generic_CDA_Stylesheet-1.3.0x.xsl";
      //string Xslt_Stylesheet = @"Xslt\NEHTA_Generic_CDA_Stylesheet-1.2.9.xsl";
      //string Xslt_Stylesheet = @"Xslt\DH_Generic_CDA_Stylesheet-1.3.0x.xsl";
      string Xslt_Stylesheet = @"Xslt\DH_Generic_CDA_Stylesheet-1.5.0.xsl";


      string CSS = @"Css\DH_Generic_CDA_Stylesheet-1.3.0x.css";
      //string CSS = @"Css\DH_Generic_CDA_Stylesheet-1.4.0x.css";
      

      string Html_Output = "Rendered_CDA_Document.html";

      //Set-up Output directory
      var OutPutDir = new DirectoryInfo("HtmlOutput");
      OutPutDir.Create();

      //Copy CSS file to output directory 
      //File.Copy(CSS, Path.Combine(OutPutDir.FullName, new FileInfo(CSS).Name), true);

      try
      {
        // Open CDA Document as an XPathDocument.
        XPathDocument doc = new XPathDocument(CDA);

        // Create a writer for writing the transformed file to the output directory.
        XmlWriter writer = XmlWriter.Create(Path.Combine(OutPutDir.FullName, Html_Output));

        // Create and load the transform using the CDA xslt Stylesheet file
        XslCompiledTransform transform = new XslCompiledTransform();
        transform.Load(Xslt_Stylesheet);

        // Execute the transformation.
        transform.Transform(doc, writer);

        //Load the html in the system browser to view.
        System.Diagnostics.Process.Start(Path.Combine(OutPutDir.FullName, Html_Output));
      } 
      catch (Exception Exec)
      {
        string xx = Exec.Message;
      }
      
    }
  }
}
