import React, { Component } from 'react';

export class Application extends Component {
    displayName = Application.name

  constructor(props) {
    super(props);
    this.state = { applications: [], loading: true };

    fetch('api/application/')
      .then(response => response.json())
      .then(data => {
        this.setState({ applications: data, loading: false });
      });
  }

  static renderApplicationsTable(applications) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Url</th>
          </tr>
        </thead>
        <tbody>
          {applications.map(application =>
              <tr key={application.id}>
                  <td>{application.id}</td>
                    <td>{application.name}</td>
                    <td>{application.url}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : Application.renderApplicationsTable(this.state.applications);

    return (
      <div>
        <h1>Applications</h1>
        <p>List all applications </p>
        {contents}
      </div>
    );
  }
}
