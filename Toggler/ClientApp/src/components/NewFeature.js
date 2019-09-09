import React, { Component } from 'react';

export class NewFeature extends Component {
    displayName = NewFeature.name

    constructor(props) {
        super(props);
        this.state = { name: "", description: "" };
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        fetch('api/feature', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                ...this.state
            })
        }).then(res =>
            window.location.href = '/features'
        );
    };

    render() {
        return (
            <div>
                <h1>New Feature</h1>
                <p>Create a new Feature </p>
                <form onSubmit={this.handleSubmit}>
                    <div class="form-group">
                        <label for="name">Name</label>
                        <input type="text" class="form-control" id="name" placeholder="Enter name of the feature" onChange={(ev) => this.setState({ name: ev.target.value })} />
                    </div>
                    <div class="form-group">
                        <label for="description">Description</label>
                        <input type="text" class="form-control" id="description" placeholder="Description of the feature" onChange={(ev) => this.setState({ description: ev.target.value })} />
                    </div>
                    <button type="submit" class="btn btn-primary">Submit</button>
                </form>
            </div>
        )
    }
}