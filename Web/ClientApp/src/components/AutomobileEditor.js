import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';

export class AutomobileEditor extends Component {
    constructor(props) {
        super(props); 
        this.state = { title: "", automobile: {}, modelsList: [], bodyTypes: [], loading: true };
        this.getData(props.match.params.carId);
    }

    render() {
        let content = this.state.loading
        ? <p><em>Loading...</em></p>
        : this.renderForm(this.state.items);
  
        return (
            <div> {content} </div>
        );
    }

    renderForm() {
        return (
            <Form onSubmit={() => this.onFormSubmit(this.state.automobile)}>
                <FormGroup>
                    <Label for="modeltype">Model</Label>
                    <Input type="select" name="modeltype" id="modeltype" defaultValue={this.state.automobile?.model?.id ?? ''} onChange={(e) => {this.handleChange2(e)}}>
                        <option value={0}>None</option> 
                        {this.state.modelsList.map(element =>
                            <option value={element.id}>{element.brandName} {element.name}</option> 
                        )}
                    </Input>
                </FormGroup>
                <FormGroup>
                    <Label for="bodyType">Body</Label>
                    <Input type="select" name="modeltype" id="bodyType" defaultValue={this.state.automobile?.body ?? ''} onChange={(e) => {this.handleChange1(e)}}>
                        <option value={0}>None</option> 
                        {this.state.bodyTypes.map(element =>
                            <option value={element}>{element}</option> 
                        )}
                    </Input>
                </FormGroup>
                <FormGroup>
                    <Label for="seatsCount">Seats Count</Label>
                    <Input id = "seatsCount" min={1} max={50} type="number" step="1" defaultValue={this.state.automobile?.seatsCount ?? ''} onChange={(e) => {this.handleChange(e)}}> </Input>
                </FormGroup>
                <Button type="submit">Submit</Button>
            </Form>
        );
    }

    async handleChange(e) {
        this.state.automobile.seatsCount = e.target.value;
    }

    async handleChange1(e) {
        this.state.automobile.body = e.target.value;
    }

    async handleChange2(e) {
        if (this.state.automobile.model) {
            this.state.automobile.model.id = e.target.value;
        } else {
            this.state.automobile.model = {id: e.target.value };
        }
    }

    async onFormSubmit(data) {
        await fetch(data.id ? 'api/Automobiles/Update' : 'api/Automobiles/Create', {
            method: "POST",
            headers: {
              "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        });
    }

    async getData(carId) {
        let response = await fetch('api/Models/ReadAll');
        const modelsList = await response.json();

        response = await fetch('api/Body/ReadAll');
        const bodyTypes = await response.json();

        let title;
        let automobile = {};
        if (carId !== "new") {
            response = await fetch(`api/Automobiles/Read/${carId}`);
            automobile = await response.json();
            title = 'Edit car';
        } else {
            title = 'Create car';
        }
        this.setState({ title, automobile, modelsList: modelsList.objects, bodyTypes, loading: false });
    }
}