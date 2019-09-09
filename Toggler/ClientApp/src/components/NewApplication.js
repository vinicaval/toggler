import React, { Component } from 'react';

export class NewApplication extends Component {
    displayName = NewApplication.name

    constructor(props) {
        super(props);
        this.state = { name: "", url: "" };
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        fetch('api/application', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                ...this.state
            })
        }).then(res =>
            window.location.href = '/applications'
        );
    };

    render() {
        return (
            <div>
                <h1>New Application</h1>
                <p>Create a new application </p>
                <form onSubmit={this.handleSubmit}>
                    <div class="form-group">
                        <label for="name">Name</label>
                        <input type="text" class="form-control" id="name" placeholder="Enter name of the application" onChange={(ev) => this.setState({ name: ev.target.value })} />
                    </div>
                    <div class="form-group">
                        <label for="description">Url</label>
                        <input type="text" class="form-control" id="description" placeholder="Url of the application" onChange={(ev) => this.setState({ url: ev.target.value })} />
                    </div>
                    <button type="submit" class="btn btn-primary">Submit</button>
                </form>
            </div>
        )
    }
}