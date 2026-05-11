/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using PresentationLayer.Views;
using System;
using System.Linq;
using System.Reflection;

namespace PresentationLayer.Presenters
{
  public class HelpAboutPresenter : IHelpAboutPresenter
  {
    IHelpAboutView _helpAboutView;

    public HelpAboutPresenter(IHelpAboutView helpAboutView)
    {
      _helpAboutView = helpAboutView;
      SubscribeToEventsSetup();
    }

    public IHelpAboutView GetHelpAboutView()
    {
      return _helpAboutView;
    }

    private void SubscribeToEventsSetup()
    {
      _helpAboutView.HelpAboutViewLoadEventRaised += new EventHandler(OnHelpAboutViewLoadEventRaised);
    }

    public void OnHelpAboutViewLoadEventRaised(object sender, EventArgs e)
    {
      _helpAboutView.SetAboutValues(
                                    AssemblyTitle(),
                                    AssemblyProduct(),
                                    AssemblyVersion(),
                                    AssemblyCopyright(),
                                    AssemblyCompany(),
                                    AssemblyDescription()
                                    );
    }

    private string AssemblyTitle()
    {
      dynamic attribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false).First();
      return attribute.Title;
    }

    private string AssemblyVersion()
    {
      return Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }

    private string AssemblyDescription()
    {
      dynamic attribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false).First();
      return attribute.Description;
    }

    private string AssemblyProduct()
    {
      dynamic attribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false).First();
      return attribute.Product;
    }

    private string AssemblyCopyright()
    {
      dynamic attribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false).First();
      return attribute.Copyright;
    }

    private string AssemblyCompany()
    {
      dynamic attribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false).First();
      return attribute.Company;
    }
  }
}
