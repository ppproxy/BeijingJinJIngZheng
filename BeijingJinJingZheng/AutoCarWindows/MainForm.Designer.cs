namespace AutoCarWindows
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView_drivers = new System.Windows.Forms.ListView();
            this.button_addirver = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox_personPhoto = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox_drivingcard = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_save_driver = new System.Windows.Forms.Button();
            this.listView_cars = new System.Windows.Forms.ListView();
            this.button_delete_car = new System.Windows.Forms.Button();
            this.button_add_car = new System.Windows.Forms.Button();
            this.tabControl_car = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_car_regtime = new System.Windows.Forms.TextBox();
            this.textBox_engine_no = new System.Windows.Forms.TextBox();
            this.textBox_car_vtype = new System.Windows.Forms.TextBox();
            this.textBox_car_type = new System.Windows.Forms.TextBox();
            this.textBox_car_model = new System.Windows.Forms.TextBox();
            this.textBox_carno = new System.Windows.Forms.TextBox();
            this.button_save_car = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox_xingshi = new System.Windows.Forms.PictureBox();
            this.pictureBox_car = new System.Windows.Forms.PictureBox();
            this.listView_passcard = new System.Windows.Forms.ListView();
            this.label13 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_selectDriver = new System.Windows.Forms.TextBox();
            this.checkBox_auto = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_request_today = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl_main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_personPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_drivingcard)).BeginInit();
            this.tabControl_car.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_xingshi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_car)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage1);
            this.tabControl_main.Controls.Add(this.tabPage2);
            this.tabControl_main.Controls.Add(this.tabPage3);
            this.tabControl_main.Location = new System.Drawing.Point(12, 14);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(690, 397);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button_addirver);
            this.tabPage1.Controls.Add(this.listView_drivers);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(682, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "驾驶员管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl_car);
            this.tabPage2.Controls.Add(this.listView_cars);
            this.tabPage2.Controls.Add(this.button_delete_car);
            this.tabPage2.Controls.Add(this.button_add_car);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(682, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "车辆管理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(682, 371);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "日志";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView_drivers
            // 
            this.listView_drivers.Location = new System.Drawing.Point(6, 6);
            this.listView_drivers.Name = "listView_drivers";
            this.listView_drivers.Size = new System.Drawing.Size(151, 316);
            this.listView_drivers.TabIndex = 0;
            this.listView_drivers.UseCompatibleStateImageBehavior = false;
            // 
            // button_addirver
            // 
            this.button_addirver.Location = new System.Drawing.Point(6, 328);
            this.button_addirver.Name = "button_addirver";
            this.button_addirver.Size = new System.Drawing.Size(75, 23);
            this.button_addirver.TabIndex = 1;
            this.button_addirver.Text = "新增驾驶员";
            this.button_addirver.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "删除驾驶员";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_save_driver);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox_drivingcard);
            this.groupBox1.Controls.Add(this.pictureBox_personPhoto);
            this.groupBox1.Location = new System.Drawing.Point(163, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 340);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "驾驶员信息";
            // 
            // pictureBox_personPhoto
            // 
            this.pictureBox_personPhoto.Location = new System.Drawing.Point(18, 116);
            this.pictureBox_personPhoto.Name = "pictureBox_personPhoto";
            this.pictureBox_personPhoto.Size = new System.Drawing.Size(216, 152);
            this.pictureBox_personPhoto.TabIndex = 0;
            this.pictureBox_personPhoto.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "驾驶证号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label3.Location = new System.Drawing.Point(19, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "个人持身份证照片";
            // 
            // pictureBox_drivingcard
            // 
            this.pictureBox_drivingcard.Location = new System.Drawing.Point(251, 116);
            this.pictureBox_drivingcard.Name = "pictureBox_drivingcard";
            this.pictureBox_drivingcard.Size = new System.Drawing.Size(216, 152);
            this.pictureBox_drivingcard.TabIndex = 0;
            this.pictureBox_drivingcard.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label4.Location = new System.Drawing.Point(252, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "驾驶证照片";
            // 
            // button_save_driver
            // 
            this.button_save_driver.Location = new System.Drawing.Point(21, 289);
            this.button_save_driver.Name = "button_save_driver";
            this.button_save_driver.Size = new System.Drawing.Size(75, 23);
            this.button_save_driver.TabIndex = 4;
            this.button_save_driver.Text = "保存修改";
            this.button_save_driver.UseVisualStyleBackColor = true;
            // 
            // listView_cars
            // 
            this.listView_cars.Location = new System.Drawing.Point(8, 13);
            this.listView_cars.Name = "listView_cars";
            this.listView_cars.Size = new System.Drawing.Size(151, 316);
            this.listView_cars.TabIndex = 3;
            this.listView_cars.UseCompatibleStateImageBehavior = false;
            // 
            // button_delete_car
            // 
            this.button_delete_car.Location = new System.Drawing.Point(89, 335);
            this.button_delete_car.Name = "button_delete_car";
            this.button_delete_car.Size = new System.Drawing.Size(75, 23);
            this.button_delete_car.TabIndex = 4;
            this.button_delete_car.Text = "删除车辆";
            this.button_delete_car.UseVisualStyleBackColor = true;
            // 
            // button_add_car
            // 
            this.button_add_car.Location = new System.Drawing.Point(8, 335);
            this.button_add_car.Name = "button_add_car";
            this.button_add_car.Size = new System.Drawing.Size(75, 23);
            this.button_add_car.TabIndex = 5;
            this.button_add_car.Text = "新增车辆";
            this.button_add_car.UseVisualStyleBackColor = true;
            // 
            // tabControl_car
            // 
            this.tabControl_car.Controls.Add(this.tabPage4);
            this.tabControl_car.Controls.Add(this.tabPage5);
            this.tabControl_car.Location = new System.Drawing.Point(174, 13);
            this.tabControl_car.Name = "tabControl_car";
            this.tabControl_car.SelectedIndex = 0;
            this.tabControl_car.Size = new System.Drawing.Size(502, 345);
            this.tabControl_car.TabIndex = 6;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(494, 319);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "车辆信息";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.listView_passcard);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(494, 319);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "进京证";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_car_regtime);
            this.groupBox2.Controls.Add(this.textBox_engine_no);
            this.groupBox2.Controls.Add(this.textBox_car_vtype);
            this.groupBox2.Controls.Add(this.textBox_car_type);
            this.groupBox2.Controls.Add(this.textBox_car_model);
            this.groupBox2.Controls.Add(this.textBox_carno);
            this.groupBox2.Controls.Add(this.button_save_car);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.pictureBox_xingshi);
            this.groupBox2.Controls.Add(this.pictureBox_car);
            this.groupBox2.Location = new System.Drawing.Point(-7, -11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 340);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "车辆信息";
            // 
            // textBox_car_regtime
            // 
            this.textBox_car_regtime.Location = new System.Drawing.Point(260, 57);
            this.textBox_car_regtime.Name = "textBox_car_regtime";
            this.textBox_car_regtime.Size = new System.Drawing.Size(74, 21);
            this.textBox_car_regtime.TabIndex = 5;
            // 
            // textBox_engine_no
            // 
            this.textBox_engine_no.Location = new System.Drawing.Point(94, 58);
            this.textBox_engine_no.Name = "textBox_engine_no";
            this.textBox_engine_no.Size = new System.Drawing.Size(100, 21);
            this.textBox_engine_no.TabIndex = 5;
            // 
            // textBox_car_vtype
            // 
            this.textBox_car_vtype.Location = new System.Drawing.Point(409, 58);
            this.textBox_car_vtype.Name = "textBox_car_vtype";
            this.textBox_car_vtype.Size = new System.Drawing.Size(85, 21);
            this.textBox_car_vtype.TabIndex = 5;
            // 
            // textBox_car_type
            // 
            this.textBox_car_type.Location = new System.Drawing.Point(394, 29);
            this.textBox_car_type.Name = "textBox_car_type";
            this.textBox_car_type.Size = new System.Drawing.Size(100, 21);
            this.textBox_car_type.TabIndex = 5;
            // 
            // textBox_car_model
            // 
            this.textBox_car_model.Location = new System.Drawing.Point(234, 29);
            this.textBox_car_model.Name = "textBox_car_model";
            this.textBox_car_model.Size = new System.Drawing.Size(100, 21);
            this.textBox_car_model.TabIndex = 5;
            // 
            // textBox_carno
            // 
            this.textBox_carno.Location = new System.Drawing.Point(78, 29);
            this.textBox_carno.Name = "textBox_carno";
            this.textBox_carno.Size = new System.Drawing.Size(100, 21);
            this.textBox_carno.TabIndex = 5;
            // 
            // button_save_car
            // 
            this.button_save_car.Location = new System.Drawing.Point(27, 282);
            this.button_save_car.Name = "button_save_car";
            this.button_save_car.Size = new System.Drawing.Size(75, 23);
            this.button_save_car.TabIndex = 4;
            this.button_save_car.Text = "保存修改";
            this.button_save_car.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label5.Location = new System.Drawing.Point(254, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "行驶证照片";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label6.Location = new System.Drawing.Point(21, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "车辆正面照片";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "发动机号码:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "车牌号:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(340, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "机动车类型:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(340, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "车辆类型:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "注册时间:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "型号:";
            // 
            // pictureBox_xingshi
            // 
            this.pictureBox_xingshi.Location = new System.Drawing.Point(253, 107);
            this.pictureBox_xingshi.Name = "pictureBox_xingshi";
            this.pictureBox_xingshi.Size = new System.Drawing.Size(216, 152);
            this.pictureBox_xingshi.TabIndex = 0;
            this.pictureBox_xingshi.TabStop = false;
            // 
            // pictureBox_car
            // 
            this.pictureBox_car.Location = new System.Drawing.Point(20, 107);
            this.pictureBox_car.Name = "pictureBox_car";
            this.pictureBox_car.Size = new System.Drawing.Size(216, 152);
            this.pictureBox_car.TabIndex = 0;
            this.pictureBox_car.TabStop = false;
            // 
            // listView_passcard
            // 
            this.listView_passcard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView_passcard.Location = new System.Drawing.Point(6, 35);
            this.listView_passcard.Name = "listView_passcard";
            this.listView_passcard.Size = new System.Drawing.Size(482, 106);
            this.listView_passcard.TabIndex = 0;
            this.listView_passcard.UseCompatibleStateImageBehavior = false;
            this.listView_passcard.View = System.Windows.Forms.View.Details;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "进京证列表";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "生效时间";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "状态";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button_request_today);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.checkBox_auto);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.textBox_selectDriver);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(6, 149);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(482, 151);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "申请进京证";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "选择驾驶员:";
            // 
            // textBox_selectDriver
            // 
            this.textBox_selectDriver.Location = new System.Drawing.Point(85, 24);
            this.textBox_selectDriver.Name = "textBox_selectDriver";
            this.textBox_selectDriver.Size = new System.Drawing.Size(100, 21);
            this.textBox_selectDriver.TabIndex = 1;
            // 
            // checkBox_auto
            // 
            this.checkBox_auto.AutoSize = true;
            this.checkBox_auto.Location = new System.Drawing.Point(200, 59);
            this.checkBox_auto.Name = "checkBox_auto";
            this.checkBox_auto.Size = new System.Drawing.Size(72, 16);
            this.checkBox_auto.TabIndex = 2;
            this.checkBox_auto.Text = "自动续期";
            this.checkBox_auto.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 3;
            this.label15.Text = "续期天数:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // button_request_today
            // 
            this.button_request_today.Location = new System.Drawing.Point(14, 99);
            this.button_request_today.Name = "button_request_today";
            this.button_request_today.Size = new System.Drawing.Size(103, 23);
            this.button_request_today.TabIndex = 4;
            this.button_request_today.Text = "立即申请(今天)";
            this.button_request_today.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "立即申请(明天)";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 428);
            this.Controls.Add(this.tabControl_main);
            this.Name = "MainForm";
            this.Text = "进京证申请助手";
            this.tabControl_main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_personPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_drivingcard)).EndInit();
            this.tabControl_car.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_xingshi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_car)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listView_drivers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_addirver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox_personPhoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox_drivingcard;
        private System.Windows.Forms.Button button_save_driver;
        private System.Windows.Forms.ListView listView_cars;
        private System.Windows.Forms.Button button_delete_car;
        private System.Windows.Forms.Button button_add_car;
        private System.Windows.Forms.TabControl tabControl_car;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_car_regtime;
        private System.Windows.Forms.TextBox textBox_engine_no;
        private System.Windows.Forms.TextBox textBox_car_vtype;
        private System.Windows.Forms.TextBox textBox_car_type;
        private System.Windows.Forms.TextBox textBox_car_model;
        private System.Windows.Forms.TextBox textBox_carno;
        private System.Windows.Forms.Button button_save_car;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox_xingshi;
        private System.Windows.Forms.PictureBox pictureBox_car;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView listView_passcard;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_selectDriver;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBox_auto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_request_today;
        private System.Windows.Forms.Button button2;
    }
}

