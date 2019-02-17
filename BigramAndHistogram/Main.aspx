<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="BigramAndHistogram.Main" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Bigram and Histogram</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
    <style type="text/css">
        .margin-T-20 {margin-top:20px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <section class="container">
            <article class="margin-T-20">

                <div id="pnl_text">
                    <label class="text-muted">Enter Text</label>  
                    <textarea runat="server" id="txtInput" class="form-control" maxlength="1000000"></textarea>
                </div> <br />

                <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" /><br />

               <%-- Panel for scrollbar incase large amount of text was inputted --%>
               <asp:Panel runat="server" ID="pnl_output" ScrollBars="Vertical" Height="300" CssClass="margin-T-20"  Visible="false">
                    <asp:Label runat="server" ID="lblOutput"></asp:Label>
               </asp:Panel>

                <div id="pnl_chart" >
                    <asp:Chart ID="BigramChart" runat="server" Width="1000px" >
                        <ChartAreas>
                            <asp:ChartArea Name="MainChartArea">
                                <AxisY Crossing="Min">
                                </AxisY>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                     <asp:Chart ID="LetterFrequencyChart" runat="server" Width="1000px" >
                        <ChartAreas>
                            <asp:ChartArea Name="MainChartArea">
                                <AxisY Crossing="Min">
                                </AxisY>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>>
                </div>
            </article>
        </section>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
</body>
</html>
