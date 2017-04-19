        public void SendMailUseGmail()
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add("2996439853@qq.com");
            msg.To.Add("wangchf@ylyato.cn");
            /*   
             msg.To.Add("b@b.com");   
            * msg.To.Add("b@b.com");   
            * msg.To.Add("b@b.com");可以发送给多人   
            */
            //msg.CC.Add(c@c.com);
            /*   
            * msg.CC.Add("c@c.com");   
            * msg.CC.Add("c@c.com");可以抄送给多人   
            */
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/test.html";
            System.IO.StreamReader read =
            new System.IO.StreamReader(filePath, System.Text.Encoding.GetEncoding("GB2312"));
            string mailBody = read.ReadToEnd();
            msg.From = new MailAddress("764297968@qq.com", "dulei", System.Text.Encoding.UTF8);
            /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
            msg.Subject = "这是测试邮件";//邮件标题    
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码    
            msg.Body = mailBody;//邮件内容    
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码    
            msg.IsBodyHtml = true;//是否是HTML邮件    
            msg.Priority = MailPriority.High;//邮件优先级    
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("764297968@qq.com", "fxcmleouhxpibffj");
            //上述写你的GMail邮箱和密码    
            client.Port = 25;//Gmail使用的端口    
            client.Host = "smtp.qq.com";
            client.EnableSsl = true;//经过ssl加密    
            object userState = msg;
            try
            {
                client.Send(msg);
                //client.SendAsync(msg, userState);
                //简单一点儿可以client.Send(msg);    
                Response.Write("<script>alert('成功')</script>");
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Response.Write("<script>alert("+ ex.Message + "'失败')</script>");
            }
        }
