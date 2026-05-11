/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using PresentationLayer.Views.UserControls;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace PresentationLayer.Presenters.UserControls
{
  public class NewsPresenter : INewsPresenter
  {
    INewsViewUC _newsViewUC;

    public INewsViewUC GetNewsViewUC()
    {
      return _newsViewUC;
    }
    public NewsPresenter(INewsViewUC newsViewUC)
    {
      _newsViewUC = newsViewUC;
    }

    public void LoadNewsPageIntoNewsView()
    {
      LoadLatestNews();
    }

    public bool ContentIsLoadedInNewsView()
    {
      return _newsViewUC.ContentIsLoadedInNewsView();
    }

    private void LoadLatestNews()
    {
     string currentDir = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
     _newsViewUC.LoadLatestNews(currentDir + @"\NewsDoc_01.pdf#toolbar=0&navpanes=0&view=FitH,FitV,FitB");
    }
  }


}
