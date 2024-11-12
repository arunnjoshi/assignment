import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ApiService } from './api.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, CommonModule, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [ApiService],
})
export class AppComponent {
  formData = {
    employeeId: '',
    companyname: '',
    verificationCode: '',
  };

  constructor(private apiService: ApiService) {}
  onSubmit() {
    console.log('Form Submitted', this.formData);

    this.apiService.submitForm(this.formData).subscribe(
      (response) => {
        console.log('API response:', response);
        alert(`Success: ${response.message}`);
      },
      (error) => {
        if (
          error?.error?.isEmploymentVerified == false &&
          error?.error?.message != null
        ) {
          alert(`error: ${error?.error?.message}`);
        } else {
          alert(
            'Error submitting form: ' + (error?.message || 'Unknown error')
          );
        }
      }
    );
  }

  numberOnlyValidation(event: Event): void {
    const inputElement = event.target as HTMLInputElement;
    inputElement.value = inputElement.value.replace(/[^0-9]/g, '');
  }
}
