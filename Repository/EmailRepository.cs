using On_Demand_Car_Wash_ApiV2.IRepository;
using System.Net.Mail;
using System.Net;
using iTextSharp.text.pdf;
using iTextSharp.text;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using On_Demand_Car_Wash_ApiV2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace On_Demand_Car_Wash_ApiV2.Repository
{
    public class EmailRepository : IEmail
    {
        private CarDbContext context;
        public EmailRepository(CarDbContext _context)
        {
            context = _context;
        }

        #region Email Generation Method
        public async Task SendEmailAsync(string email, string subject, string body)
        {

            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("sparklewashonline@gmail.com", "yzceoztvkjwkwbdw");

                var message = new MailMessage();
                message.From = new MailAddress("sparklewashonline@gmail.com");
                message.To.Add(new MailAddress(email));
                message.Subject = subject;
                message.Body = body;

                await smtpClient.SendMailAsync(message);
            }
        }
        #endregion Email Generation Method



        #region Invoive Pdf Generation and Sending to mail 

        public async Task GenerateAndSendInvoice(int id)
        {

          var orderObj= await context.Orders.FindAsync(id);
            var carObj = await context.Cars.FindAsync(orderObj.CarId);
            var userObj = await context.UserDetails.FindAsync(orderObj.CustId);
            var addressObj= await context.Addresses.FindAsync(orderObj.AddressId);
            var packageObj = await context.Packages.FindAsync(orderObj.PackageId);
            Payment paymentObj=null;
            if(orderObj.PaymentId !=0)
            {
                paymentObj = await context.Payments.FindAsync(orderObj.PaymentId);
            }

            UserDetail washerObj;
            if (orderObj.PaymentId != 0)
            {
                washerObj = await context.UserDetails.FindAsync(orderObj.WasherId);
            }

            // Create a new PDF document
            Document document = new Document();

            // Create a PDF writer to write the document to a memory stream
            MemoryStream memStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memStream);

            // Open the document
            document.Open();

            Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD);
            // Add content to the document

            if (paymentObj!=null)
            {


                // Create the content for the PDF document
                document.Add(new Paragraph($"Date: {DateTime.Now}\r\n" +
                      $"Invoice Number: {EncryptString(Convert.ToString(orderObj.Id))}\r\n\r\n", boldFont));
                document.Add(new Paragraph("Customer Information:\r\n" +
                      $"Name: {orderObj.CustomerName} \r\n" +
                      $"Address: {addressObj.CustAddress},{addressObj.City},{addressObj.State},{addressObj.Country},{addressObj.Pincode}\r\n" +
                      $"Phone: {orderObj.PhoneNumber}\r\n" +
                      $"Email: {userObj.Email}\r\n\r\n", boldFont));
                document.Add(new Paragraph("Car Details:\r\n" +
                      $"Make: {carObj.Name}\r\n" +
                      $"Model: {carObj.Model}\r\n" +
                      $"License Plate: {carObj.CarNumber}\r\n\r\n", boldFont));
                document.Add(new Paragraph("Services Provided:\r\n" +
                      $"Service Name: {packageObj.Name}\r\n" +
                      $"Service Description: {packageObj.Description}\r\n" +
                      $"Subtotal: {packageObj.Price}\r\n" +
                      $"Tax (10%): {(packageObj.Price * 0.10).ToString("0.00")}\r\n" +
                      $"Total: {orderObj.TotalCost}\r\n\r\n", boldFont));
                document.Add(new Paragraph("Payment Information:\r\n" +
                      "Payment Method: Gpay\r\n" +
                      $"Transaction ID: {paymentObj.TransactionId}\r\n\r\n", boldFont));
                document.Add(new Paragraph("If you have any questions or concerns regarding this invoice, please feel free to contact us at [Customer support contact details]." +
                      " Thank you for choosing our car wash services. We appreciate your business and look forward to serving you again in the future.\r\n\r\n" +
                      "Best regards,\r\n" +
                      "Sparkle Wash Online\r\n" +
                      "123 Main Street,\r\nCityville,\r\nStateville,\r\n12345,\r\nIndia.\r\n" +
                      "1800-121-6532\r\n" +
                      "sparklewashonline@gmail.com\r\n" +
                      "www.sparklewashonline.com", boldFont));
            }
            else
            {
                document.Add(new Paragraph($"Date: {DateTime.Now}\r\n" +
                     $"Invoice Number: {EncryptString(Convert.ToString(orderObj.Id))}\r\n\r\n", boldFont));
                document.Add(new Paragraph("Customer Information:\r\n" +
                      $"Name: {orderObj.CustomerName} \r\n" +
                      $"Address: {addressObj.CustAddress},{addressObj.City},{addressObj.State},{addressObj.Country},{addressObj.Pincode}\r\n" +
                      $"Phone: {orderObj.PhoneNumber}\r\n" +
                      $"Email: {userObj.Email}\r\n\r\n", boldFont));
                document.Add(new Paragraph("Car Details:\r\n" +
                      $"Make: {carObj.Name}\r\n" +
                      $"Model: {carObj.Model}\r\n" +
                      $"License Plate: {carObj.CarNumber}\r\n\r\n", boldFont));
                document.Add(new Paragraph("Services Provided:\r\n" +
                      $"Service Name: {packageObj.Name}\r\n" +
                      $"Service Description: {packageObj.Description}\r\n" +
                      $"Subtotal: {packageObj.Price}\r\n" +
                      $"Tax (10%): {(packageObj.Price * 0.10).ToString("0.00")}\r\n" +
                      $"Total: {orderObj.TotalCost}\r\n\r\n", boldFont));
                document.Add(new Paragraph("Payment Information:\r\n" +
                      "Payment Method: Cash After Wash\r\n\r\n", boldFont));
                document.Add(new Paragraph("If you have any questions or concerns regarding this invoice, please feel free to contact us at [Customer support contact details]." +
                      " Thank you for choosing our car wash services. We appreciate your business and look forward to serving you again in the future.\r\n\r\n" +
                      "Best regards,\r\n" +
                      "Sparkle Wash Online\r\n" +
                      "123 Main Street,\r\nCityville,\r\nStateville,\r\n12345,\r\nIndia.\r\n" +
                      "1800-121-6532\r\n" +
                      "sparklewashonline@gmail.com\r\n" +
                      "www.sparklewashonline.com", boldFont));
            }
            

            // Close the document
            document.Close();

            // Convert the memory stream to a byte array
            byte[] pdfBytes = memStream.ToArray();

            // GenerateInvoicePDF();


            // Sender's email credentials
            string senderEmail = "sparklewashonline@gmail.com";
            string senderPassword = "yzceoztvkjwkwbdw";

            // Recipient's email address
           // string recipientEmail = "hcpyadav2509@gmail.com";

            // new NetworkCredential("sparklewashonline@gmail.com", "yzceoztvkjwkwbdw");

            // Create a new SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            // Create a new mail message
            MailMessage mailMessage = new MailMessage(senderEmail,userObj.Email);
            mailMessage.Subject = "Invoice";
            mailMessage.Body = $"Dear {userObj.Email},\n\n" +
                $"Please find attached the invoice #{EncryptString(Convert.ToString(orderObj.Id))} for the amount of {orderObj.TotalCost:C}.\n\n" +
                "Thank you for your business.";

            // Create an attachment from the PDF bytes
            MemoryStream attachmentStream = new MemoryStream(pdfBytes);
            Attachment attachment = new Attachment(attachmentStream, "invoice.pdf", "application/pdf");
            // E:\On_Demand_Car_Wash_Project\On_Demand_Car_Wash_ApiV2\invoice.pdf

            // Add the attachment to the mail message
            mailMessage.Attachments.Add(attachment);

            try
            {
                // Send the email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Invoice sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while sending the invoice: " + ex.Message);
            }
            finally
            {
                // Clean up resources
                attachment.Dispose();
                attachmentStream.Dispose();
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }



        #endregion Invoive Pdf Generation and Sending to mail




        #region Invoive Number Encryption 
        public string EncryptString(string originalString)
        {
            string key = "MySecretKey12345";
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16]; // Initialization Vector (IV) should be unique and random for each encryption

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] inputBytes = Encoding.UTF8.GetBytes(originalString);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                string encryptedString = Convert.ToBase64String(encryptedBytes);
                return encryptedString;
            }
        }
        #endregion Invoive Number Encryption 



        #region Invoive Number Decryption 
        public string DecryptString(string encryptedString)
        {
            string key = "MySecretKey12345";
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16]; // Initialization Vector (IV) should be the same as used during encryption

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                byte[] encryptedBytes = Convert.FromBase64String(encryptedString);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                string decryptedString = Encoding.UTF8.GetString(decryptedBytes);
                return decryptedString;
            }
        }


        #endregion Invoive Number Decryption




        #region Reset Password Email Method
        public async Task<bool> RestPasswordMail(EmailDTO recipientEmail)
        {
            //var user = await context.UserDetails.FindAsync(recipientEmail.Email);
            var user = await context.UserDetails.FirstOrDefaultAsync(
                    x => x.Email == recipientEmail.Email);

            if (user==null)
            {
                return false;
            }

            string resetPasswordLink = "http://localhost:4200/resetpassword";  // Reset password link

            // Email details
            string senderEmail = "sparklewashonline@gmail.com";  // Email address of the sender
            string senderName = "Sparkle Wash Online";  // Name of the sender
            string emailSubject = "Reset Your Password";
            string emailBody = $"Dear User,<br><br>You have requested to reset your password. Please click the following link to reset your password: <a href='{resetPasswordLink}'>Reset Password</a>.<br><br>If you didn't request this, please ignore this email.<br><br>Best regards,<br>{senderName}";



            try
            {
                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("sparklewashonline@gmail.com", "yzceoztvkjwkwbdw");

                    using (var message = new MailMessage(senderEmail, recipientEmail.Email))
                    {
                        message.Subject = emailSubject;
                        message.Body = emailBody;
                        message.IsBodyHtml = true;

                        client.Send(message);
                       // Console.WriteLine("Reset password email sent successfully.");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending the reset password email: {ex.Message}");
            }
            return false;
        }
        #endregion Reset Password Email Method
    }




}


















