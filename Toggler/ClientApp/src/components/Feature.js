import React, { Component } from 'react';
import { Glyphicon } from 'react-bootstrap';

export class Feature extends Component {
    displayName = Feature.name

  constructor(props) {
    super(props);
    this.state = { features: [], loading: true };

    fetch('api/feature/')
      .then(response => response.json())
      .then(data => {
        this.setState({ features: data, loading: false });
      });
  }

  static renderFeaturesTable(features) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Description</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {features.map(feature =>
              <tr key={feature.id}>
                  <td>{feature.id}</td>
                  <td>{feature.name}</td>
                  <td>{feature.description}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : Feature.renderFeaturesTable(this.state.features);

    return (
      <div>
        <h1>Features</h1>
        <p>List all available features </p>
        {contents}
      </div>
    );
  }
}
