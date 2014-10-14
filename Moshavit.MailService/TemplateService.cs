using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity;
using Moshavit.Entity.Interfaces;

namespace Moshavit.MailService
{
    public class TemplateService : ITemplateService
    {
        #region Members
        private IDataBase<EmailTemplate> _dataBase;
        #endregion

        #region Constructor
        public TemplateService(IDataBase<EmailTemplate> dataBase)
        {
            _dataBase = dataBase;
        }
        #endregion

        #region Public Method
        public void AddTempalte(EmailTemplate template)
        {
            var oldTemplate = GetTemplate(template.Name);

            if (oldTemplate != null)
            {
                UpdateTemplate(template);
            }
            else
            {
                _dataBase.Add(template);
            }
        }

        public void UpdateTemplate(EmailTemplate template)
        {
            var oldTemplate = GetTemplate(template.Name);
            template.Id = oldTemplate.Id;
            _dataBase.Update(template);
        }

        public EmailTemplate GetTemplate(string name)
        {
            try
            {
                return _dataBase.FindBy(t => t.Name == name).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        public string EmailContent(string name)
        {
            var template = GetTemplate(name);

            return template.Content;
        }
        #endregion
    }
}
