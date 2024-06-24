import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";

@Component({
  selector: "app-contact",
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: "./contact.component.html",
  styleUrl: "./contact.component.css",
})
export class ContactComponent implements OnInit {
  contactForm!: FormGroup;
  resultado: string = "";

  constructor(private formBuilder: FormBuilder) {
    this.contactForm = this.formBuilder.group({
      email: ["", [Validators.required, Validators.email]],
      mensaje: ["", [Validators.required, Validators.minLength(10)]],
    });
  }

  ngOnInit(): void {}

  enviar(event: SubmitEvent) {
    event.preventDefault();
    console.log(this.contactForm.value);
    this.resultado = JSON.stringify(this.contactForm.value);
  }

  hasErrors(campo: string, tipoError: string) {
    return this.contactForm.get(campo)?.hasError(tipoError) && this.contactForm.get(campo)?.touched;
  }
}
