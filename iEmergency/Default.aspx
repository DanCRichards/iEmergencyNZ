<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iEmergency._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
          <h1>iEmergency - New Zealand</h1>
           <h3><span id="lblUserFullName" runat="server"></span></h3>

        <br />

        <a class="btn btn-danger btn-lg" href="EmergencyCall">Start Emergency Call &raquo;</a>
            
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Fire Service</h2>
            <p>
                The Fire Service require during an emergency: 
               <br />
                <ul>
                    <li>Location of the emergency
                        <ul>
                            <li>Street Address</li>
                            <li>Nearest Intersection or cross roads</li>
                        </ul>
                    </li>
                    <li>Nature of the emergency 
                        <ul>
                            <li>What is happening</li>
                            <li>When did it happen</li>
                        </ul>
                    </li>
                </ul>
                </p>
            <p>
                <a class="btn btn-default" href="https://fireandemergency.nz/in-the-event-of-fire/what-to-do-if-you-see-a-fire/">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Police</h2>
            <p>
               When contacting the police you need to give as much information as possible, they will ask for the following basic information:
                <ul>
                    <li>Location of the Emergency</li>
                    <li>Nature of the Emergency
                        <ul>
                            <li>You need to be specific and answer all questions clearly given by the police.</li>
                        </ul>

                    </li>

                </ul>
                <a class="btn btn-default" href="http://www.police.govt.nz/contact-us/calling-emergency-111">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>St John</h2>
            <p>

               When contacting St John,make sure you have the following:
                <ul>
                    <li>Location of the Emergency</li>
                    <li>Nature of the Emergency
                        <ul>
                            <li>You need to be specific and answer all questions clearly given by the police.</li>
                        </ul>

                    </li>

                </ul>
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
