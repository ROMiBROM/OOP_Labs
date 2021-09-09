#pragma once

namespace Project3 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Timer^ timer1;
	protected:

	protected:

	protected:
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::Button^ button1;
	private: System::Windows::Forms::Button^ button2;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Timer^ timer2;
	private: System::ComponentModel::IContainer^ components;

	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->timer2 = (gcnew System::Windows::Forms::Timer(this->components));
			this->SuspendLayout();
			// 
			// timer1
			// 
			this->timer1->Interval = 10;
			this->timer1->Tick += gcnew System::EventHandler(this, &MyForm::timer1_Tick);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Script MT Bold", 13.8F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label1->Location = System::Drawing::Point(250, 148);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(162, 29);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Hello Yongster";
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(85, 280);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(146, 31);
			this->button1->TabIndex = 1;
			this->button1->Text = L"ВКЛ/ВЫКЛ(1)";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm::button1_Click);
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(351, 280);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(146, 31);
			this->button2->TabIndex = 2;
			this->button2->Text = L"ВКЛ/ВЫКЛ(2)";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &MyForm::button2_Click);
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Vivaldi", 13.8F, static_cast<System::Drawing::FontStyle>((System::Drawing::FontStyle::Bold | System::Drawing::FontStyle::Italic)),
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(0)));
			this->label2->Location = System::Drawing::Point(309, 70);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(53, 29);
			this->label2->TabIndex = 3;
			this->label2->Text = L"Hi";
			// 
			// timer2
			// 
			this->timer2->Interval = 10;
			this->timer2->Tick += gcnew System::EventHandler(this, &MyForm::timer2_Tick);
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(648, 391);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->label1);
			this->Name = L"MyForm";
			this->Text = L"MyForm";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
		int i = 2;
		int x = 250;
		int y = 148;
	private: System::Void timer1_Tick(System::Object^ sender, System::EventArgs^ e) {
		x = x + i;
		label1->Location = System::Drawing::Point(x, y-29);
		if (x > 450)
		{
			x = -70;
		}
	}
	private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) {
		timer1->Enabled = !timer1->Enabled;
	}
	private: System::Void button2_Click(System::Object^ sender, System::EventArgs^ e) {
		timer2->Enabled = !timer2->Enabled;
	}
		   int x1 = 309;
		   int y1 = 70;
private: System::Void timer2_Tick(System::Object^ sender, System::EventArgs^ e) {
	x1 = x1 + i;
	label2->Location = System::Drawing::Point(x1, y1-20);
	if (x1 > 450)
	{
		x1 = -70;
	}
}
};
}