USE [OnlineBookShop]
GO
/****** Object:  Table [dbo].[AdminAccount]    Script Date: 9/25/2018 7:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminAccount](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [nvarchar](15) NULL,
	[AdminPassword] [nvarchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 9/25/2018 7:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [nchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[SKU] [nvarchar](50) NULL,
	[Image] [nvarchar](255) NULL,
	[Link] [nvarchar](255) NOT NULL,
	[Company] [nvarchar](255) NULL,
	[Author] [nvarchar](50) NULL,
	[PublishDay] [date] NULL,
	[Publisher] [nvarchar](10) NULL,
	[CoverType] [nchar](10) NULL,
	[Price] [float] NULL,
	[PageNum] [int] NULL,
	[Quantity] [int] NULL,
	[status] [nvarchar](10) NULL,
	[Size] [nvarchar](50) NULL,
	[Description] [nvarchar](4000) NULL,
	[Catagory] [nvarchar](50) NULL,
	[isDeleted] [bit] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdminAccount] ON 

INSERT [dbo].[AdminAccount] ([AdminId], [AdminName], [AdminPassword]) VALUES (1, N'khang@gmail.com', N'khang123')
SET IDENTITY_INSERT [dbo].[AdminAccount] OFF
INSERT [dbo].[Books] ([BookId], [Name], [SKU], [Image], [Link], [Company], [Author], [PublishDay], [Publisher], [CoverType], [Price], [PageNum], [Quantity], [status], [Size], [Description], [Catagory], [isDeleted]) VALUES (N'KT0001    ', N'Marketing trên một trang giấy trắng', N'1516216216', N'Marketing trên một trang giấy trắng.jpg', N'/Info/BookDetails', N'kyanon digital', N'Philip Kotler', CAST(N'2018-09-21' AS Date), N'Khang', N'Bìa cứng  ', 120000, 120, 10, N'còn hàng', N'15 x 15 cm', N'
Marketing trên mạng xã hội ngày nay đã trở thành một phần không thể thiếu trong sự phát triển của bất kỳ doanh nghiệp hiện đại nào. Sự phổ biến ngày càng tăng của blog, podcast và mạng xã hội nói chung cho phép mọi tổ chức và cá nhân quảng bá sản phẩm hoặc dịch vụ họ cung cấp đến với hàng trăm triệu khán giả tiềm năng toàn cầu. Không ai muốn bỏ qua kênh tiếp thị giàu tiềm năng này, nhưng sử dụng nó sao cho hiệu quả lại là một bài toán không dễ dàng chút nào.


Các chuyên gia hàng đầu về marketing, bao gồm giáo sư Philip Kotler, tiến sĩ Marc Oliver Opresnik và phó giáo sư, tiến sĩ Svend Hollensen đã cùng hợp tác để viết nên Marketing Trên Một Trang Giấy - cuốn sách hướng dẫn bạn khám phá tường tận thế giới Digital Marketing nói chung và Marketing trên mạng xã hội nói riêng. Bằng cách tiếp cận khách quan, ngôn ngữ rõ ràng, ngắn gọn, tác phẩm trợ giúp bạn lập kế hoạch và thực hiện các chiến dịch một cách thông minh, đo lường được kết quả và theo dõi lợi tức đầu tư.


Dù bạn là người mới bắt đầu đang bị quá tải bởi quá nhiều lựa chọn, hay là một chuyên gia nhiều kinh nghiệm đang muốn cải thiện cuộc chơi của mình, Marketing Trên Một Trang Giấycũng có thể đưa bạn vượt lên những hiểu biết thông thường về tiếp thị mạng xã hội để trở thành một tay chơi khôn ngoan trên thị trường đã rất đông đúc hiện nay.', N'Kinh tế', 0)
INSERT [dbo].[Books] ([BookId], [Name], [SKU], [Image], [Link], [Company], [Author], [PublishDay], [Publisher], [CoverType], [Price], [PageNum], [Quantity], [status], [Size], [Description], [Catagory], [isDeleted]) VALUES (N'KT0002    ', N'Marketing Trong Cuộc Cách Mạng Công Nghệ 4', N'8398721204367', N'Marketing Trong Cuộc Cách Mạng Công Nghệ 4.0.jpg', N'/Info/BookDetails', N'1980 Books', N'Philip Kotler', CAST(N'2018-09-22' AS Date), N'Thế Giới', N'Bìa mềm   ', 82500, 232, 15, N'còn hàng', N'13 x 20.5 cm', N'Trong kỷ nguyên 4.0, khi hàng loạt đổi thay đang diễn ra từng phút; mọi doanh nghiệp và tổ chức đều phải chịu tác động của những xu thế lớn. Vì vậy, công việc marketing - tiếp thị cũng buộc phải thay đổi nhanh chóng, để hoạt động kinh doanh và phát triển không bị thụt lùi.

Philip Kotler, người được mệnh danh là "cha đẻ của marketing hiện đại", đã cùng các cộng sự viết nên tác phẩm "Marketing trong cuộc cách mạng công nghệ 4.0" để kịp thời định hướng kinh doanh cho các tổ chức. Cuốn sách mô tả các nguyên tắc marketing trong thế kỷ 21 và chỉ ra cách các doanh nghiệp có thể đạt được sự bền vững trên thị trường thông qua tiếp thị bằng phương tiện truyền thông mới – những bí quyết marketing phong cách 4.0. 

Đọc cuốn sách này, mọi nhà tiếp thị sẽ phải suy nghĩ lại về triết lý marketing, từ đó xây dựng một phương pháp tiếp cận toàn diện và bền vững hơn, phát triển hướng tới mọi bộ phận, mọi chức năng và mọi vị trí nhân sự. "Marketing trong cuộc cách mạng công nghệ 4.0" là cuốn cẩm nang không thể thiếu cho những chuyên gia marketing trong kỷ nguyên mới - những người đang cố gắng tận dụng các tiềm năng để cải tổ doanh nghiệp từ bên trong và kết nối sâu sắc hơn với khách hàng. ', N'Kinh tế', 1)
INSERT [dbo].[Books] ([BookId], [Name], [SKU], [Image], [Link], [Company], [Author], [PublishDay], [Publisher], [CoverType], [Price], [PageNum], [Quantity], [status], [Size], [Description], [Catagory], [isDeleted]) VALUES (N'KT0003    ', N'Tiếp Thị Phá Cách', N'9164473688750', N'Tiếp Thị Phá Cách.jpg', N'/Info/BookDetails', N'NXB Trẻ', N'Philip Kotler', CAST(N'2014-12-01' AS Date), N'Trẻ', N'Bìa mềm   ', 58500, 232, 10, N'còn hàng', N'13.5 x 20.5 cm', N'Ngày nay các nhà tiếp thị phải đối mặt với một thách thức khó khăn: làm sao để đổi mới trong một thị trường siêu phân khúc và cạnh tranh khốc liệt. Nền kinh tế tiêu dùng đã bị bão hòa với những sản phẩm na ná nhau và người tiêu dùng càng ngày càng trở nên miễn dịch với những thông điệp quảng cáo. Tất cả đã làm cho tiếp thị truyền thống - tiêu biểu với biện pháp phân khúc thị trường và tạo ra nhiều thương hiệu - bắt đầu mất tác dụng.', N'Kinh tế', 0)
