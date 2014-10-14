using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.Interfaces
{
    public interface ITemplateService
    {
        /// <summary>
        /// Add a new template to data base
        /// </summary>
        /// <param name="template">email template</param>
        void AddTempalte(EmailTemplate template);

        /// <summary>
        /// Update the email template
        /// </summary>
        /// <param name="template">email template</param>
        void UpdateTemplate(EmailTemplate template);

        /// <summary>
        /// Get the template by name
        /// </summary>
        /// <param name="name">template name</param>
        /// <returns>Email template Object</returns>
        EmailTemplate GetTemplate(string name);

        /// <summary>
        /// retrieve email content by template name
        /// </summary>
        /// <param name="name">template name</param>
        /// <returns>email content</returns>
        string EmailContent(string name);
    }
}
