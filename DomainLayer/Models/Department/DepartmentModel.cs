/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Department
{
     public class DepartmentModel : IDepartmentModel
    {
        public int DepartmentId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Department name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Department name must be between 5 and 20 characters")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "URL is a Required field.")]
        [RegularExpression(@"^((http|ftp|https|www)://)?([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$",
               ErrorMessage = "URL format is incorrect")]
        public string DepartmentUrl { get; set; }

        [Required(ErrorMessage = "Phone is a Required field.")]
        [RegularExpression(@"^[01]?[\(\)\.\- ]{0,}[0-9]{3}[\(\)\.\- ]{0,}[0-9]{3}[\(\)\.\- ]{0,}[0-9]{4}[\(\)\.\- ]{0,}$",
               ErrorMessage = "Phone format is incorrect")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is a Required field.")]
        [RegularExpression(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$",
                 ErrorMessage = "Email format is incorrect")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "City must be between 5 and 20 characters")]
        public string CityLocation { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "State is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "State must be between 2 and 20 characters")]
        public string StateLocation { get; set; }
    }
}
