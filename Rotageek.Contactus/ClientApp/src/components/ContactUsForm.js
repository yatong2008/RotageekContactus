import React, { Component } from 'react';
import { FormErrors } from './FormErrors.js';
import './ContactUsForm.css';

export class ContactUsForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            postData: {},
            formErrors: {},
            formVisibility: true
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.validateField = this.validateField.bind(this);
    }

    handleSubmit(e) {
        e.preventDefault();
        console.log('form submission data', this.state.postData);
        let formData = new FormData();
        for (let key in this.state.postData) {
            formData.append(key, this.state.postData[key]);
        }

        window.fetch("/Contactus/Create",
            {
                method: "POST",
                body: formData
            }).then(() => {
                this.setState({ formVisibility: false });
        });
    }

    handleInputChange(event) {
        const target = event.target;
        const name = target.name;
        const { postData } = this.state;

        let partialState = postData;
        partialState[name] = event.target.value;

        this.setState({ postData: partialState }, () => { this.validateField(name, target.value) });

    }

    validateField(fieldName, value) {
        let fieldValidationErrors = this.state.formErrors;
        let emailValid = this.state.emailValid;

        switch (fieldName) {
        case 'Email':
            emailValid = value.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i);

            if (!emailValid) {
                fieldValidationErrors.email = ' is invalid';
            } else {
                delete fieldValidationErrors.email;
            }

            break;
        default:
            break;
        }
        this.setState({
            formErrors: fieldValidationErrors,
            emailValid: emailValid
        }, this.validateForm);
    }

    render() {
        console.log(this.state.FormVisibility);

        if (this.state.formVisibility) {
            return (
                <div className="ContactUsForm" >
                    <h1>Contact Us</h1>
                    <div>
                        <form onSubmit={this.handleSubmit}>
                            <div className="form-group">
                                <label className="control-label">Name</label>
                                <input type="text" name="Name" className="form-control" onChange={this.handleInputChange} />
                            </div>
                            <div className="form-group">
                                <label className="control-label">Email</label>
                                <input type="text" name="Email" className="form-control" onChange={this.handleInputChange} />
                                <div className="panel panel-default text-danger">
                                    <FormErrors formErrors={this.state.formErrors} />
                                </div>
                            </div>
                            <div className="form-group">
                                <label className="control-label">Address</label>
                                <input type="text" name="Address" className="form-control" onChange={this.handleInputChange} />
                            </div>
                            <div className="form-group">
                                <label className="control-label">Message</label>
                                <input type="text" name="Message" className="form-control" onChange={this.handleInputChange} />
                            </div>
                            <div className="form-group">
                                <button htmltype="submit" disabled={Object.keys(this.state.formErrors).length > 0} className="btn btn-primary" >Submit</button>
                            </div>
                        </form>
                    </div>
                </div>
            );
        } else {
            return (
                <div>
                    <span>Thank your for contacting us!</span>
                </div>
            );
        }
    }

}